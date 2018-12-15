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
        public DbSet<Players> Player { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<Rights> Right { get; set; }
        public DbSet<Notes> Note { get; set; }
        public DbSet<Classes> Class { get; set; }
        public DbSet<Specs> Spec { get; set; }
        public DbSet<GameRoles> GameRole { get; set; }
        public DbSet<PlayerProfessions> PlayerProfession { get; set; }
        public DbSet<Professions> Profession { get; set; }
        public DbSet<PlayerAttunements> PlayerAttunement { get; set; }
        public DbSet<Attunements> Attunement { get; set; }
        public DbSet<BankContributions> BankContribution { get; set; }
        public DbSet<Promotions> Promotion { get; set; }
        public DbSet<GuildRanks> GuildRank { get; set; }
        public DbSet<RaidAttendance> RaidAttendance { get; set; }
        public DbSet<RaidInstances> RaidInstance { get; set; }
        public DbSet<Raids> Raid { get; set; }
        public DbSet<Bosses> Bosses { get; set; }
        public DbSet<Encounters> Encounter { get; set; }
        public DbSet<EncounterLoots> EncounterLoot { get; set; }
        public DbSet<Loots> Loot { get; set; }
    }
}