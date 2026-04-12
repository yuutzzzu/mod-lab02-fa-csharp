using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }
    public class FA
    {
        public static State a = new State()
        {
            Name = "a",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State b = new State()
        {
            Name = "b",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State c = new State()
        {
            Name = "c",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };

        State InitialState = a;

        public FA()
        {
            a.Transitions['0'] = a;
            a.Transitions['1'] = b;
            b.Transitions['0'] = c;
            b.Transitions['1'] = a;
            c.Transitions['0'] = b;
            c.Transitions['1'] = c;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s) // цикл по всем символам 
            {
                current = current.Transitions[c]; // меняем состояние на то, в которое у нас переход
                if (current == null)              // если его нет, возвращаем признак ошибки
                    return null;
                // иначе переходим к следующему
            }
            return current.IsAcceptState;         // результат true если в конце финальное состояние 
        }
    }

    public class FA1
    {
        State q0 = new State() { Name = "q0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        State q1 = new State() { Name = "q1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        State q2 = new State() { Name = "q2", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        State q3 = new State() { Name = "q3", IsAcceptState = true, Transitions = new Dictionary<char, State>() };
        State qDead = new State() { Name = "qDead", IsAcceptState = false, Transitions = new Dictionary<char, State>() };

        State InitialState;

        public FA1()
        {
            InitialState = q0;

            q0.Transitions['0'] = q2;
            q0.Transitions['1'] = q1;

            q1.Transitions['0'] = q3;
            q1.Transitions['1'] = q1;

            q2.Transitions['0'] = qDead;
            q2.Transitions['1'] = q3;

            q3.Transitions['0'] = qDead;
            q3.Transitions['1'] = q3;

            qDead.Transitions['0'] = qDead;
            qDead.Transitions['1'] = qDead;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;

                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    public class FA2
    {
        State q00 = new State() { Name = "q00", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        State q01 = new State() { Name = "q01", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        State q10 = new State() { Name = "q10", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        State q11 = new State() { Name = "q11", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

        State InitialState;

        public FA2()
        {
            InitialState = q00;

            q00.Transitions['0'] = q10;
            q00.Transitions['1'] = q01;

            q01.Transitions['0'] = q11;
            q01.Transitions['1'] = q00;

            q10.Transitions['0'] = q00;
            q10.Transitions['1'] = q11;

            q11.Transitions['0'] = q01;
            q11.Transitions['1'] = q10;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;

                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        State q0 = new State() { Name = "q0", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        State q1 = new State() { Name = "q1", IsAcceptState = false, Transitions = new Dictionary<char, State>() };
        State q2 = new State() { Name = "q2", IsAcceptState = true, Transitions = new Dictionary<char, State>() };

        State InitialState;

        public FA3()
        {
            InitialState = q0;

            q0.Transitions['0'] = q0;
            q0.Transitions['1'] = q1;

            q1.Transitions['0'] = q0;
            q1.Transitions['1'] = q2;

            q2.Transitions['0'] = q2;
            q2.Transitions['1'] = q2;
        }

        public bool? Run(IEnumerable<char> s)
        {
            State current = InitialState;
            foreach (var c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;

                current = current.Transitions[c];
            }
            return current.IsAcceptState;
        }
    }

    class fa
    {
        static void Main(string[] args)
        {
            String s = "0000010111";
            FA fa = new FA();
            bool? result = fa.Run(s);
            Console.WriteLine(result);
        }
    }
}
