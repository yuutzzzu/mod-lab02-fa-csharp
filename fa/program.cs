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
    
public class FA1
{
    private State q0;
    private State q1;
    private State q2;
    private State q3;
    private State q4;
    
    public FA1()
    {
        q0 = new State { Name = "q0", IsAcceptState = false };
        q1 = new State { Name = "q1", IsAcceptState = false };
        q2 = new State { Name = "q2", IsAcceptState = false };
        q3 = new State { Name = "q3", IsAcceptState = true };
        q4 = new State { Name = "q4", IsAcceptState = false };

        q0.Transitions = new Dictionary<char, State>();
        q1.Transitions = new Dictionary<char, State>();
        q2.Transitions = new Dictionary<char, State>();
        q3.Transitions = new Dictionary<char, State>();
        q4.Transitions = new Dictionary<char, State>();

        q0.Transitions['0'] = q2;
        q0.Transitions['1'] = q1;

        q1.Transitions['0'] = q3;
        q1.Transitions['1'] = q1; 

        q2.Transitions['0'] = q4; 
        q2.Transitions['1'] = q3; 

        q3.Transitions['0'] = q4; 
        q3.Transitions['1'] = q3; 

        q4.Transitions['0'] = q4;
        q4.Transitions['1'] = q4;
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
        private State q00;
        private State q01;
        private State q10;
        private State q11;
        
        public FA2()
        {
            q00 = new State { Name = "q00", IsAcceptState = false }; 
            q01 = new State { Name = "q01", IsAcceptState = false }; 
            q10 = new State { Name = "q10", IsAcceptState = false };
            q11 = new State { Name = "q11", IsAcceptState = true };
    
            q00.Transitions = new Dictionary<char, State>();
            q01.Transitions = new Dictionary<char, State>();
            q10.Transitions = new Dictionary<char, State>();
            q11.Transitions = new Dictionary<char, State>();

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
            State current = q00;
            
            foreach (char c in s)
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
        private State q0;
        private State q1;
        private State q2;
        
        public FA3()
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

            q2.Transitions['0'] = q2;
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

    class Program
    {
        static void Main(string[] args)
        {
            String s = "0000010111";
            
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine($"FA1 (ровно один 0 и хотя бы одна 1): {result1}");
            
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine($"FA2 (нечетное 0 и нечетное 1): {result2}");
            
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine($"FA3 (содержит '11'): {result3}");
        }
    }
}
