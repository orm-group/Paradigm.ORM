﻿using System;
using Paradigm.ORM.Data.Attributes;

namespace Paradigm.ORM.Tests.Mocks.Cql
{
    [Table]
    public class SimpleTable: ISimpleTable
    {
        [Column(Type = "int")]
        [PrimaryKey]
        public int Id { get; set; }

        [Column(Type = "text")]
        public string Name { get; set; }

        [Column(Type = "boolean")]
        public bool IsActive { get; set; }

        [Column(Type = "decimal")]
        public decimal Amount { get; set; }

        [Column(Type = "date")]
        public DateTime CreatedDate { get; set; }

    }
}