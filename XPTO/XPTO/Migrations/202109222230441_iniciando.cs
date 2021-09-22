namespace XPTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iniciando : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Sobrenome = c.String(nullable: false),
                        CPF = c.Int(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Idade = c.Int(nullable: false),
                        MaiorDeIdade = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pessoa");
        }
    }
}
