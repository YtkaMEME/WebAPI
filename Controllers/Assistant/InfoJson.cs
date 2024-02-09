    
public class InfoJson
{
    public string status { get; set; }
    public string request_id { get; set; }
    public Rooms[] rooms { get; set; }
    public object[] groups { get; set; }
    public Devices[] devices { get; set; }
    public Scenarios[] scenarios { get; set; }
    public Households[] households { get; set; }
}

public class Rooms
{
    public string id { get; set; }
    public string name { get; set; }
    public string household_id { get; set; }
    public string[] devices { get; set; }
}

public class Devices
{
    public string id { get; set; }
    public string name { get; set; }
    public object[] aliases { get; set; }
    public string type { get; set; }
    public string external_id { get; set; }
    public string skill_id { get; set; }
    public string household_id { get; set; }
    public string room { get; set; }
    public object[] groups { get; set; }
    public Capabilities[] capabilities { get; set; }
    public Properties[] properties { get; set; }
    public Quasar_info quasar_info { get; set; }
}

public class Capabilities
{
    public bool reportable { get; set; }
    public bool retrievable { get; set; }
    public string type { get; set; }
    public Parameters parameters { get; set; }
    public State state { get; set; }
    public double last_updated { get; set; }
}

public class Parameters
{
    public string instance { get; set; }
    public string unit { get; set; }
    public bool random_access { get; set; }
    public bool looped { get; set; }
    public Range range { get; set; }
    public Temperature_k temperature_k { get; set; }
    public bool split { get; set; }
}

public class Range
{
    public int min { get; set; }
    public int max { get; set; }
    public int precision { get; set; }
}

public class Temperature_k
{
    public int min { get; set; }
    public int max { get; set; }
}

public class State
{
    public string instance { get; set; }
    public object value { get; set; }
}

public class Properties
{
    public string type { get; set; }
    public bool reportable { get; set; }
    public bool retrievable { get; set; }
    public Parameters1 parameters { get; set; }
    public State1 state { get; set; }
    public double state_changed_at { get; set; }
    public double last_updated { get; set; }
}

public class Parameters1
{
    public string instance { get; set; }
    public string unit { get; set; }
    public Events[] events { get; set; }
}

public class Events
{
    public string value { get; set; }
}

public class State1
{
    public string instance { get; set; }
    public double value { get; set; }
}

public class Quasar_info
{
    public string device_id { get; set; }
    public string platform { get; set; }
}

public class Scenarios
{
    public string id { get; set; }
    public string name { get; set; }
    public bool is_active { get; set; }
}

public class Households
{
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
}