using System;

abstract class Character
{
    private readonly string _characterType;
    
    protected Character(string characterType)
    {
        _characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => _characterType == "Wizard" ? true : false;

    public override string ToString() => $"Character is a {_characterType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    private bool prepared = false;

    public Wizard() : base("Wizard")
    {
        
    }

    public override int DamagePoints(Character target) => prepared ? 12 : 3;

    public void PrepareSpell() => prepared = true;

    public override bool Vulnerable() => prepared ? false : true;
    
}
