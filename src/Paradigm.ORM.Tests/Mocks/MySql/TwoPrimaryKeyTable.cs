﻿using Paradigm.ORM.Data.Attributes;

namespace Paradigm.ORM.Tests.Mocks.MySql
{
    [Table("twoprimarykeytable", Catalog = "test")]
    public class TwoPrimaryKeyTable : ITwoPrimaryKeyTable
    {
        [Column(Type = "int")]
        [PrimaryKey]
        public int Id1 { get; set; }

        [Column(Type = "int")]
        [PrimaryKey]
        public int Id2 { get; set; }

        [Column(Type = "varchar")]
        public string Name { get; set; }
    }
}