using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SerTerraQueijaria.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbClientes",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbClientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "tbTiposProdutos",
                columns: table => new
                {
                    TiposProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoProduto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbTiposProdutos", x => x.TiposProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "tbPedidos",
                columns: table => new
                {
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorDesconto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbPedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_tbPedidos_tbClientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tbClientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbProdutos",
                columns: table => new
                {
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtdEstoque = table.Column<int>(type: "int", nullable: false),
                    TiposProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbProdutos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_tbProdutos_tbTiposProdutos_TiposProdutoId",
                        column: x => x.TiposProdutoId,
                        principalTable: "tbTiposProdutos",
                        principalColumn: "TiposProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbItensPedido",
                columns: table => new
                {
                    ItensPedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbItensPedido", x => x.ItensPedidoId);
                    table.ForeignKey(
                        name: "FK_tbItensPedido_tbPedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "tbPedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbItensPedido_tbProdutos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "tbProdutos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbItensPedido_PedidoId",
                table: "tbItensPedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbItensPedido_ProdutoId",
                table: "tbItensPedido",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbPedidos_ClienteId",
                table: "tbPedidos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tbProdutos_TiposProdutoId",
                table: "tbProdutos",
                column: "TiposProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbItensPedido");

            migrationBuilder.DropTable(
                name: "tbPedidos");

            migrationBuilder.DropTable(
                name: "tbProdutos");

            migrationBuilder.DropTable(
                name: "tbClientes");

            migrationBuilder.DropTable(
                name: "tbTiposProdutos");
        }
    }
}
