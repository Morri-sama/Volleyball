using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DbContexts
{
    public class VolleyballDbContext : DbContext
    {
        public VolleyballDbContext(DbContextOptions<VolleyballDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Position>().HasData(new Position[]
            {
                new Position(){Id=1, Name="Позиция 1 — справа сзади.", Description="Занимает подающий доигровщик — нападает из зоны IIтемпа. Обладает сильным ударом, способен работать с мячом — закручивать, тушевать."},
                new Position(){Id=2, Name="Позиция 2 — справа впереди.", Description="Занимает диагональный — участник команды, который принимает самое большое число подач. Он должен быть самым прыгучим и сильным. Рост игрока не менее 195 см-2 м. Согласно занимаемой позиции на площадке игроку требуется выполнять мощные подачи."},
                new Position(){Id=3, Name="Позиция 3 — посредине впереди.", Description="Занимает центральный блокирующий (нападающий из зоны Iтемпа) — игрок, способный принимать низкие мячи, обладающий высокой реактивностью. Должен уметь создать эффект неожиданности на поле при парировании атаки соперников."},
                new Position(){Id=4, Name="Позиция 4 — слева впереди.", Description="Место доигровщика (работает в зоне Iтемпа) — участник команды, атакующий с края сетки. Принимая во внимание позиции игроков на площадке, он вынужден часто принимать подачи связующего и атаковать. Нужен сильный удар. Игрок обязан отлично видеть ход игры и исход подачи."},
                new Position(){Id=5, Name="Позиция 5 — слева сзади.", Description="Занимает связующий или плеймейкер — участник команды, которому принадлежит право второго удара после атаки соперников. Его задача так подать мяч нападающему, чтобы тот смог провести результативный удар. Нужно обладать скоростью реакции и точностью подачи."},
                new Position(){Id=6, Name="Позиция 6 — посредине сзади.", Description="Занимает блокирующий — самый высокий и выносливый член команды. Он блокирует удары."},
            });
            base.OnModelCreating(builder);
        }

        public DbSet<Action> Actions { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Rally> Rallies { get; set; }
        public DbSet<Set> Sets { get; set; }
    }
}
