namespace CajeroAutomatico.Persistencia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atms",
                c => new
                    {
                        atmId = c.Int(nullable: false, identity: true),
                        desAtm = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.atmId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        clienteId = c.Int(nullable: false, identity: true),
                        nomcliente = c.String(nullable: false, maxLength: 150),
                        correoCliente = c.String(nullable: false, maxLength: 150),
                        direcCliente = c.String(maxLength: 150),
                        telCliente = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.clienteId);
            
            CreateTable(
                "dbo.Cuentas",
                c => new
                    {
                        cuentaId = c.Int(nullable: false, identity: true),
                        numeroCuenta = c.Int(nullable: false),
                        numTarjeta = c.String(nullable: false, maxLength: 20),
                        pin = c.Int(nullable: false),
                        saldoDisponible = c.Decimal(nullable: false, precision: 18, scale: 2),
                        tipoCuentaId = c.Int(nullable: false),
                        clienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cuentaId)
                .ForeignKey("dbo.Clientes", t => t.clienteId, cascadeDelete: true)
                .ForeignKey("dbo.TipoCuentas", t => t.tipoCuentaId, cascadeDelete: true)
                .Index(t => t.tipoCuentaId)
                .Index(t => t.clienteId);
            
            CreateTable(
                "dbo.TipoCuentas",
                c => new
                    {
                        tipoCuentaId = c.Int(nullable: false, identity: true),
                        desTipoCuenta = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.tipoCuentaId);
            
            CreateTable(
                "dbo.DispensadorEfectivos",
                c => new
                    {
                        dispensadorEfectivoId = c.Int(nullable: false, identity: true),
                        ubicacion = c.String(nullable: false, maxLength: 100),
                        dineroTotal = c.Int(nullable: false),
                        estadoDispensadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.dispensadorEfectivoId)
                .ForeignKey("dbo.EstadoDispensadores", t => t.estadoDispensadorId, cascadeDelete: true)
                .Index(t => t.estadoDispensadorId);
            
            CreateTable(
                "dbo.EstadoDispensadores",
                c => new
                    {
                        estadoDispensadorId = c.Int(nullable: false, identity: true),
                        desEstDispensador = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.estadoDispensadorId);
            
            CreateTable(
                "dbo.Retiros",
                c => new
                    {
                        retiroId = c.Int(nullable: false, identity: true),
                        fechaRetiro = c.DateTime(nullable: false),
                        montoRetiro = c.DateTime(nullable: false),
                        atmId = c.Int(nullable: false),
                        dispensadorEfectivoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.retiroId)
                .ForeignKey("dbo.Atms", t => t.atmId, cascadeDelete: true)
                .ForeignKey("dbo.DispensadorEfectivos", t => t.dispensadorEfectivoId, cascadeDelete: true)
                .Index(t => t.atmId)
                .Index(t => t.dispensadorEfectivoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Retiros", "dispensadorEfectivoId", "dbo.DispensadorEfectivos");
            DropForeignKey("dbo.Retiros", "atmId", "dbo.Atms");
            DropForeignKey("dbo.DispensadorEfectivos", "estadoDispensadorId", "dbo.EstadoDispensadores");
            DropForeignKey("dbo.Cuentas", "tipoCuentaId", "dbo.TipoCuentas");
            DropForeignKey("dbo.Cuentas", "clienteId", "dbo.Clientes");
            DropIndex("dbo.Retiros", new[] { "dispensadorEfectivoId" });
            DropIndex("dbo.Retiros", new[] { "atmId" });
            DropIndex("dbo.DispensadorEfectivos", new[] { "estadoDispensadorId" });
            DropIndex("dbo.Cuentas", new[] { "clienteId" });
            DropIndex("dbo.Cuentas", new[] { "tipoCuentaId" });
            DropTable("dbo.Retiros");
            DropTable("dbo.EstadoDispensadores");
            DropTable("dbo.DispensadorEfectivos");
            DropTable("dbo.TipoCuentas");
            DropTable("dbo.Cuentas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Atms");
        }
    }
}
