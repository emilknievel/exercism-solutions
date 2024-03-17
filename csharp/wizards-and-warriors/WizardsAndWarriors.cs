abstract class Character
{
    protected string CharacterType => GetType().Name;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {CharacterType}";
}

class Warrior : Character
{
    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    private bool _spellPrepared;

    public override int DamagePoints(Character target) => _spellPrepared ? 12 : 3;

    public void PrepareSpell()
    {
        _spellPrepared = true;
    }

    public override bool Vulnerable() => !_spellPrepared;
}
