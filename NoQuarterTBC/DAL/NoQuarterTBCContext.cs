using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NoQuarterTBC.Models;

namespace NoQuarterTBC.DAL
{
    public class NoQuarterTBCContext : DbContext
    {
        public NoQuarterTBCContext() : base("NoQuarterTBCContext")
        {
            
        }

        // For each table in the Database - Please refer to LucidChart for the diagram.
        // https://www.lucidchart.com/documents/edit/2fe6e207-765c-4a10-8167-666a6e089b3c/1
        //
        public DbSet<Player> Player { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Privilege> Right { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Spec> Spec { get; set; }
        public DbSet<GameRole> GameRole { get; set; }
        public DbSet<PlayerProfession> PlayerProfession { get; set; }
        public DbSet<Profession> Profession { get; set; }
        public DbSet<PlayerAttunement> PlayerAttunement { get; set; }
        public DbSet<Attunement> Attunement { get; set; }
        public DbSet<BankContribution> BankContribution { get; set; }
        public DbSet<Promotion> Promotion { get; set; }
        public DbSet<GuildRank> GuildRank { get; set; }
        public DbSet<RaidAttendance> RaidAttendance { get; set; }
        public DbSet<RaidInstance> RaidInstance { get; set; }
        public DbSet<Raid> Raid { get; set; }
        public DbSet<Boss> Bosses { get; set; }
        public DbSet<Encounter> Encounter { get; set; }
        public DbSet<EncounterLoot> EncounterLoot { get; set; }
        public DbSet<Loot> Loot { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<PlayerRecipe> PlayerRecipe { get; set; }
    }
}