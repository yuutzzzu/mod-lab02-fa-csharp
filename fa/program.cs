using System;
using System.Collections.Generic;
using System.Linq;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }

    public class FA1
    {
        private State q0, q1, q2;
        
        public FA1()
        {
            q0 = new State { Name = "q0", IsAcceptState = false };
            q1 = new State { Name = "q1", IsAcceptState = false };
            q2 = new State { Name = "q2", IsAcceptState = true };

            q0.Transitions = new Dictionary<char, State>();
            q1.Transitions = new Dictionary<char, State>();
            q2.Transitions = new Dictionary<char, State>();

            q0.Transitions['0'] = q0;
            q0.Transitions['1'] = q1;

            q1.Transitions['0'] = q0;
            q1.Transitions['1'] = q2;

            q2.Transitions['0'] = q0;
            q2.Transitions['1'] = q2;
        }
        
        public bool? Run(IEnumerable<char> s)
        {
            State current = q0;
            
            foreach (char c in s)
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
        private State q0, q1, q2, q3, q4; 
        
        public FA2()
        {
            q0 = new State { Name = "q0", IsAcceptState = false }; 
            q1 = new State { Name = "q1", IsAcceptState = false };
            q2 = new State { Name = "q2", IsAcceptState = false };
            q3 = new State { Name = "q3", IsAcceptState = false }; 
            q4 = new State { Name = "q4", IsAcceptState = true };  

            q0.Transitions = new Dictionary<char, State>();
            q1.Transitions = new Dictionary<char, State>();
            q2.Transitions = new Dictionary<char, State>();
            q3.Transitions = new Dictionary<char, State>();
            q4.Transitions = new Dictionary<char, State>();

            q0.Transitions['0'] = q1;
            q0.Transitions['1'] = null; 

            q1.Transitions['0'] = q2;
            q1.Transitions['1'] = null;

            q2.Transitions['0'] = q2;  
            q2.Transitions['1'] = q3; 

            q3.Transitions['0'] = q2;
            q3.Transitions['1'] = q4;

            q4.Transitions['0'] = null;
            q4.Transitions['1'] = null;
        }
        
        public bool? Run(IEnumerable<char> s)
        {
            State current = q0;
            
            foreach (char c in s)
            {
                if (!current.Transitions.ContainsKey(c) || current.Transitions[c] == null)
                    return false; 
                current = current.Transitions[c];
            }
            
            return current.IsAcceptState;
        }
    }
    
    public class FA3
    {
        private State evenZeros, oddZeros;
        
        public FA3()
        {
            evenZeros = new State { Name = "even", IsAcceptState = true }; 
            oddZeros = new State { Name = "odd", IsAcceptState = false };
            
            evenZeros.Transitions = new Dictionary<char, State>();
            oddZeros.Transitions = new Dictionary<char, State>();
            
            evenZeros.Transitions['0'] = oddZeros;
            oddZeros.Transitions['0'] = evenZeros;
            
            evenZeros.Transitions['1'] = evenZeros;
            oddZeros.Transitions['1'] = oddZeros;
        }
        
        public bool? Run(IEnumerable<char> s)
        {
            State current = evenZeros;
            
            foreach (char c in s)
            {
                if (!current.Transitions.ContainsKey(c))
                    return null;
                current = current.Transitions[c];
            }
            
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}
