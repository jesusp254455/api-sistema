﻿using api_sistema.modells;
using Microsoft.EntityFrameworkCore;

namespace api_sistema
{
    public class dcontext:DbContext
    {
        public dcontext()
        {

        }
        public dcontext(DbContextOptions<dcontext> options) : base(options)
        {

        }
        public DbSet <t_usuario> t_usuario { get; set; }
        public DbSet<t_rol> t_rol { get; set; }
        public DbSet<t_tipodocumento> t_tipodocumento { get; set; }
        public DbSet<t_categoria> t_categoria { get; set; }
        public DbSet<t_producto> t_producto { get; set; }
    }
}