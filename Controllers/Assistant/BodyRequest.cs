using System.Collections.Generic;
using System.Dynamic;

namespace WebApplication2.RequestsToYa
{
    public class BodyRequest
    {
        public List<Device> Devices = new List<Device>();
    }

    public class Device
    {
        public string id { get; set; }
        public List<Action> actions = new List<Action>();

        public Device(string index, Action action)
        {
            id = index;
            actions.Add(action);
        }
    }

    public class Action
    {
        public string type { get; set; }
        public ExpandoObject State;

        public Action(string ty, ExpandoObject st)
        {
            type = ty;
            State = st;
        }
    }
    
}