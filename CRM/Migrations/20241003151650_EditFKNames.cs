using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.Migrations
{
    /// <inheritdoc />
    public partial class EditFKNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_Appointments_AppointmentsAppointmentId",
                table: "AppointmentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_OfferedServices_OfferedServicesOfferedS~",
                table: "AppointmentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOfferedServices_Companies_CompaniesCompanyId",
                table: "CompanyOfferedServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOfferedServices_OfferedServices_OfferedServicesOffer~",
                table: "CompanyOfferedServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAppointments_Appointments_AppointmentsAppointmentId",
                table: "CustomerAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAppointments_Customers_CustomersCustomerId",
                table: "CustomerAppointments");

            migrationBuilder.RenameColumn(
                name: "CustomersCustomerId",
                table: "CustomerAppointments",
                newName: "AppointmentId");

            migrationBuilder.RenameColumn(
                name: "AppointmentsAppointmentId",
                table: "CustomerAppointments",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAppointments_CustomersCustomerId",
                table: "CustomerAppointments",
                newName: "IX_CustomerAppointments_AppointmentId");

            migrationBuilder.RenameColumn(
                name: "OfferedServicesOfferedServiceId",
                table: "CompanyOfferedServices",
                newName: "OfferedServiceId");

            migrationBuilder.RenameColumn(
                name: "CompaniesCompanyId",
                table: "CompanyOfferedServices",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyOfferedServices_OfferedServicesOfferedServiceId",
                table: "CompanyOfferedServices",
                newName: "IX_CompanyOfferedServices_OfferedServiceId");

            migrationBuilder.RenameColumn(
                name: "OfferedServicesOfferedServiceId",
                table: "AppointmentServices",
                newName: "OfferedServiceId");

            migrationBuilder.RenameColumn(
                name: "AppointmentsAppointmentId",
                table: "AppointmentServices",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentServices_OfferedServicesOfferedServiceId",
                table: "AppointmentServices",
                newName: "IX_AppointmentServices_OfferedServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_Appointments",
                table: "AppointmentServices",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_OfferedServices",
                table: "AppointmentServices",
                column: "OfferedServiceId",
                principalTable: "OfferedServices",
                principalColumn: "OfferedServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOfferedServices_Companies",
                table: "CompanyOfferedServices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOfferedServices_OfferedServices",
                table: "CompanyOfferedServices",
                column: "OfferedServiceId",
                principalTable: "OfferedServices",
                principalColumn: "OfferedServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAppointments_Appointments",
                table: "CustomerAppointments",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAppointments_Customers",
                table: "CustomerAppointments",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_Appointments",
                table: "AppointmentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentServices_OfferedServices",
                table: "AppointmentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOfferedServices_Companies",
                table: "CompanyOfferedServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyOfferedServices_OfferedServices",
                table: "CompanyOfferedServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAppointments_Appointments",
                table: "CustomerAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAppointments_Customers",
                table: "CustomerAppointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "CustomerAppointments",
                newName: "CustomersCustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "CustomerAppointments",
                newName: "AppointmentsAppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAppointments_AppointmentId",
                table: "CustomerAppointments",
                newName: "IX_CustomerAppointments_CustomersCustomerId");

            migrationBuilder.RenameColumn(
                name: "OfferedServiceId",
                table: "CompanyOfferedServices",
                newName: "OfferedServicesOfferedServiceId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "CompanyOfferedServices",
                newName: "CompaniesCompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyOfferedServices_OfferedServiceId",
                table: "CompanyOfferedServices",
                newName: "IX_CompanyOfferedServices_OfferedServicesOfferedServiceId");

            migrationBuilder.RenameColumn(
                name: "OfferedServiceId",
                table: "AppointmentServices",
                newName: "OfferedServicesOfferedServiceId");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "AppointmentServices",
                newName: "AppointmentsAppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_AppointmentServices_OfferedServiceId",
                table: "AppointmentServices",
                newName: "IX_AppointmentServices_OfferedServicesOfferedServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_Appointments_AppointmentsAppointmentId",
                table: "AppointmentServices",
                column: "AppointmentsAppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentServices_OfferedServices_OfferedServicesOfferedS~",
                table: "AppointmentServices",
                column: "OfferedServicesOfferedServiceId",
                principalTable: "OfferedServices",
                principalColumn: "OfferedServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOfferedServices_Companies_CompaniesCompanyId",
                table: "CompanyOfferedServices",
                column: "CompaniesCompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyOfferedServices_OfferedServices_OfferedServicesOffer~",
                table: "CompanyOfferedServices",
                column: "OfferedServicesOfferedServiceId",
                principalTable: "OfferedServices",
                principalColumn: "OfferedServiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAppointments_Appointments_AppointmentsAppointmentId",
                table: "CustomerAppointments",
                column: "AppointmentsAppointmentId",
                principalTable: "Appointments",
                principalColumn: "AppointmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAppointments_Customers_CustomersCustomerId",
                table: "CustomerAppointments",
                column: "CustomersCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
