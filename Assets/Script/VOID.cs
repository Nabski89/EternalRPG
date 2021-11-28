/*
Properties allow you to fire events when values are set, for instance:

public string Name {
    get { return name; }
    set {
        name = value;
        var eh = NameChanged;   // avoid race condition.
        if (eh != null)
            eh(this, EventArgs.Empty);
    }
}
private string name;
public event EventHandler NameChanged;
An added bonus is that you can track when your property gets set or read by putting breakpoints in the getter/setter with your debugger or diagnostic print statements.
*/