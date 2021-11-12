#include <string>
#include <vector>
#include <algorithm>
#include <iostream>
#include <fstream>
#include<TCHAR.H>

typedef unsigned char uchar;

using namespace std;

class format_error : public runtime_error {
public:
    format_error(const char* msg) : runtime_error(msg) {}
};

class StateReader { //class for reading states from file
public:
    struct ElementarySwitch { // one switch for automat
        int initialState;      // number of current state
        uchar letter;          // reading symbol
        bool isTerminalState;  // is next state terminal?
        int nextState;         // number of next state
        ElementarySwitch() :
            initialState(-1),
            letter(0),
            isTerminalState(false),
            nextState(-1)
        {}

        // next 2 operators - for sorting states array
        friend bool operator > (const ElementarySwitch& el, const ElementarySwitch& er) {
            if (el.initialState > er.initialState) return true;
            if (el.initialState == er.initialState) {
                if (el.letter > er.letter) return true;
                if (el.letter == er.letter) {
                    if (el.isTerminalState != er.isTerminalState) return er.isTerminalState;
                    if (el.nextState > er.nextState) return true;
                }
            }
            return false;
        }

        friend bool operator < (const ElementarySwitch& el, const ElementarySwitch& er) {
            return !operator>(el, er);
        }
    };

    typedef vector<ElementarySwitch> StatesSwitchArray;

    StateReader(const char* filename);
    ~StateReader() { stateFile.close(); }

protected:
    StatesSwitchArray statemachineStates; // array of switches for automat

private:
    ifstream stateFile; // stream for reading file
};

StateReader::StateReader(const char* filename) :stateFile(filename) {
    if (!stateFile.is_open()) throw runtime_error("Invalid states file"); // can't open file

    string tmpStr;
    while (getline(stateFile, tmpStr)) {
        if (tmpStr.size() == 0) continue; // skip empty string
        // several check for input file format
        if (tmpStr[0] != 'q' && tmpStr[0] != 'Q')
            throw format_error("Line must begin with 'q' letter");
        string::size_type commaPos = tmpStr.find(',');
        if (commaPos == string::npos)
            throw format_error("There is no comma");
        string stateNumber = tmpStr.substr(1, commaPos - 1);
        ElementarySwitch tmpSw; // prepare next elementh in array
        tmpSw.initialState = atoi(stateNumber.c_str());
        if (tmpSw.initialState == 0 && stateNumber[0] != '0')
            throw format_error("State number must contains digits only");
        tmpSw.letter = tmpStr[commaPos + 1];
        if (tmpStr[commaPos + 2] != '=')
            throw format_error("Expected '=' sign");
        switch (tmpStr[commaPos + 3]) {
        case 'f':
        case 'F':
            tmpSw.isTerminalState = true;
            break;
        case 'q':
        case 'Q':
            tmpSw.isTerminalState = false;
            break;
        default:
            throw format_error("Next state must begin with 'q' or 'f' letter");
        }
        stateNumber = tmpStr.substr(commaPos + 4);
        tmpSw.nextState = atoi(stateNumber.c_str());
        if (tmpSw.nextState == 0 && stateNumber[0] != '0')
            throw format_error("State number must contains digits only");

        statemachineStates.push_back(tmpSw); // add one switch to array of switches
    }
}

class StateMachine : public StateReader {
public:
    StateMachine(const char* filename);
    bool isDeterministic() const { return deterministic; }
    bool hasHangs() const { return hangs; } // means that graph contains isolated node(s)
    const StateReader::StatesSwitchArray& GetSwitches() const { return statemachineStates; } // just for printing
    bool isExpressionCorrect(const string& expression, int& errorPos);

protected:
    void SortStates();
    bool _isDeterministic();
    bool _hasHangs();
    int _findNextIndex(int curState, uchar sym);

private:
    bool deterministic;
    bool hangs;
};

StateMachine::StateMachine(const char* filename) :
    StateReader(filename),
    deterministic(true),
    hangs(false)
{
    SortStates();
    //some little check of machine
    if (statemachineStates.size() == 0)
        throw runtime_error("Automat is empty");
    if (statemachineStates[0].initialState != 0)
        throw runtime_error("There is no initial state");
    size_t ln = statemachineStates.size();
    bool hasFinalState = false;
    for (size_t i = 0; i < ln; i++)
        if (hasFinalState = statemachineStates[i].isTerminalState)
            break;
    if (!hasFinalState)
        throw runtime_error("There is no final state");

    deterministic = _isDeterministic(); // check if automat is deterministic
    hangs = _hasHangs();                // check if may be hangs
}

bool StateMachine::_isDeterministic() {
    size_t ln = statemachineStates.size(); // count of elements in array
    bool isDet = true;
    for (size_t i = 1; i < ln; i++)
        if (statemachineStates[i - 1].initialState == statemachineStates[i].initialState &&
            statemachineStates[i - 1].letter == statemachineStates[i].letter &&
            (statemachineStates[i - 1].isTerminalState != statemachineStates[i].isTerminalState ||
                statemachineStates[i - 1].nextState != statemachineStates[i].nextState))
        {
            isDet = false;
            break;
        };

    return isDet;
}

bool StateMachine::_hasHangs() {
    size_t ln = statemachineStates.size();
    bool isHangs = false;
    for (size_t i = 0; i < ln; i++) {
        if (!statemachineStates[i].isTerminalState) {
            bool found = false;
            // very bad algorithm to search in _SORTED_ array. I was laziness to do better :->
            for (size_t j = 0; j < ln; j++) {
                if (statemachineStates[i].nextState == statemachineStates[j].initialState) {
                    found = true;
                    break;
                }
            }
            if (!found) {
                isHangs = true;
                break;
            }
        }
    }
    return isHangs;
}

void StateMachine::SortStates() {
    sort(statemachineStates.begin(), statemachineStates.end()); // common sorting algorithm from <algorithm>
}

int StateMachine::_findNextIndex(int curState, uchar sym) {
    int found = -1;
    size_t ln = statemachineStates.size();

    // very bad algorithm to search in _SORTED_ array
    for (size_t j = 0; j < ln; j++) {
        if (statemachineStates[j].initialState == curState &&
            statemachineStates[j].letter == sym) {
            found = j;
            break;
        }
    }
    return found;
}

bool StateMachine::isExpressionCorrect(const string& expression, int& errorPos) {
    if (!deterministic || hangs)
        throw runtime_error("This automat cannot check expression");
    // emulate automat's task
    int currentState = 0;
    size_t strLen = expression.size();
    for (int i = 0; i < strLen; i++) {
        int idx = _findNextIndex(currentState, expression[i]);
        if (idx < 0) {
            errorPos = i;
            return false;
        }
        if (statemachineStates[idx].isTerminalState) {
            if (i == strLen - 1) return true;
            errorPos = i + 1;
            return false;
        }
        currentState = statemachineStates[idx].nextState;
    }
    errorPos = strLen;
    return false;
}

int _tmain(int argc, _TCHAR* argv[]) {
    try { // try to create object of StateMachine
        //StateMachine sr("var1.txt");
        //StateMachine sr("var2.txt");
        StateMachine sr("var3_nd.txt");
        StateReader::StatesSwitchArray::const_iterator it; // another way to access to array's elements
        for (it = sr.GetSwitches().begin(); it != sr.GetSwitches().end(); it++)
            cout << "q" << it->initialState << "," << it->letter << "=" << (it->isTerminalState ? "f" : "q") << it->nextState << endl;
        cout << "There are" << (sr.hasHangs() ? "" : "n't") << " hangs" << endl;
        cout << "Automat is" << (sr.isDeterministic() ? "" : "n't") << " deterministic" << endl;

        string testExpr;
        cout << "Please, enter expression to check ";
        //cin >> testExpr;
        //testExpr = "/a\"g*"; // var1
        //testExpr = "/a\"g*"; //var2
        testExpr = "aeb"; //var3
        cout << endl<<testExpr<<endl;
        int err;
        bool res = sr.isExpressionCorrect(testExpr, err);
        if (res) cout << "Expression is correct!" << endl;
        else cout << "Incorrect expression. Error position: " << err << endl;
    }
    catch (const exception& err) {
        cerr << err.what() << endl;
    }
    return 0;
}