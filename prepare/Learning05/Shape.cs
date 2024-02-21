using System.Drawing;
using System.Security.Cryptography.X509Certificates;

public class Shape{

    protected string _color;

    public Shape(string color){

        _color = color;
    }

    public string GetColor(){
        return _color;
    }

    public void SetColor(string color){

        _color = color;
    }
    public virtual double GetArea(){

        throw new NotImplementedException();

    }

}