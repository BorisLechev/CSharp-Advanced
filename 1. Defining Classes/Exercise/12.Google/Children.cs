public class Children
{
    public string ChildrenName { get; set; }
    public string ChildrenBirthday { get; set; }

    public Children(string childrenName, string childrenBirthday)
    {
        this.ChildrenName = childrenName;
        this.ChildrenBirthday = childrenBirthday;
    }

    public override string ToString()
    {
        return $"{this.ChildrenName} {this.ChildrenBirthday}";
    }
}