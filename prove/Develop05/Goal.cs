using System.Runtime.CompilerServices;

public abstract class Goal {

    public string _shortName;
    public string _description;
    public string _points;

    public Goal(string name, string description, string points){
        _description = description;
        _shortName = name;
        _points = points;

    }

    public virtual void RecordEvent(){
        
        IsComplete();
    }

    public virtual bool IsComplete(){

        return false;
    }

    public virtual string GetDetailString(){
        return "";
    }

    public  virtual string GetStringRepresentation(){
        return "";
    }

}