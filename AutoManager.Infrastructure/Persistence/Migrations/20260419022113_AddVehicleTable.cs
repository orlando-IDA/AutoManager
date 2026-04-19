using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoManager.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_Vehicles_VehicleId",
                table: "OrdemServico");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Cliente_CustomerId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Veiculo");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Veiculo",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Veiculo",
                newName: "Montadora");

            migrationBuilder.RenameColumn(
                name: "LicensePlate",
                table: "Veiculo",
                newName: "Placa");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_CustomerId",
                table: "Veiculo",
                newName: "IX_Veiculo_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_Veiculo_VehicleId",
                table: "OrdemServico",
                column: "VehicleId",
                principalTable: "Veiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Cliente_CustomerId",
                table: "Veiculo",
                column: "CustomerId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_Veiculo_VehicleId",
                table: "OrdemServico");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Cliente_CustomerId",
                table: "Veiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo");

            migrationBuilder.RenameTable(
                name: "Veiculo",
                newName: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "Placa",
                table: "Vehicles",
                newName: "LicensePlate");

            migrationBuilder.RenameColumn(
                name: "Montadora",
                table: "Vehicles",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Vehicles",
                newName: "Model");

            migrationBuilder.RenameIndex(
                name: "IX_Veiculo_CustomerId",
                table: "Vehicles",
                newName: "IX_Vehicles_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_Vehicles_VehicleId",
                table: "OrdemServico",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Cliente_CustomerId",
                table: "Vehicles",
                column: "CustomerId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
