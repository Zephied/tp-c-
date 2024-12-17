using WpfApp4.Model;

public class CombatViewModel : BaseViewModel
{
    public Monster PlayerMonster { get; set; }
    public Monster EnemyMonster { get; set; }

    private int playerHp;
    public int PlayerHp
    {
        get { return playerHp; }
        set { playerHp = value; OnPropertyChanged(); }
    }

    private int enemyHp;
    public int EnemyHp
    {
        get { return enemyHp; }
        set { enemyHp = value; OnPropertyChanged(); }
    }

    public CombatViewModel(Monster playerMonster)
    {
        PlayerMonster = playerMonster;
        GenerateEnemyMonster();
        PlayerHp = PlayerMonster.Health;
        EnemyHp = EnemyMonster.Health;
    }

    private void GenerateEnemyMonster()
    {
        using (var context = new GameDbContext())
        {
            var enemy = context.Monsters.OrderBy(m => Guid.NewGuid()).FirstOrDefault();
            EnemyMonster = new Monster
            {
                Name = enemy.Name,
                Health = (int)(enemy.Health * 1.1), // 10% boost
                Spells = enemy.Spells
            };
        }
    }

    public void PlayerAttack(Spell spell)
    {
        EnemyHp -= spell.Damage;
        if (EnemyHp <= 0)
        {
            // Enemy defeated logic
        }
    }

    public void EnemyAttack()
    {
        var randomSpell = EnemyMonster.Spells.OrderBy(s => Guid.NewGuid()).FirstOrDefault();
        PlayerHp -= randomSpell.Damage;
        if (PlayerHp <= 0)
        {
            // Player defeated logic
        }
    }
}
