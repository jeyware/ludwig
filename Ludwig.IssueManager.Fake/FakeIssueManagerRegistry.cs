using System;
using System.Collections.Generic;
using Ludwig.Contracts.Di;

namespace Ludwig.IssueManager.Fake
{
    public class FakeIssueManagerRegistry:IRegistry
    {
        public Type IssueManager { get; } = typeof(FakeIssueManager);
        public List<Type> Authenticators { get; } = new List<Type> { typeof(UsernamePasswordAuthenticator) };
        public List<Type> AdditionalTransientServices { get; } = new List<Type>();
        public List<Type> AdditionalSingletonServices { get; } = new List<Type>();
        public Dictionary<Type, Type> AdditionalTransientInjections { get; set; } = new Dictionary<Type, Type>();
        public Dictionary<Type, Type> AdditionalSingletonInjections { get; set; } = new Dictionary<Type, Type>();
    }
}