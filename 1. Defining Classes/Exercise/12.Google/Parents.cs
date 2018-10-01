public class Parents
{
    public string ParentName { get; set; }
    public string ParentBirthday { get; set; }

    public Parents(string parentName, string parentBirthday)
    {
        this.ParentName = parentName;
        this.ParentBirthday = parentBirthday;
    }

    public override string ToString()
    {
        return $"{this.ParentName} {this.ParentBirthday}";
    }
}