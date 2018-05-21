using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CapstoneData.Migrations
{
    public partial class Addinitialentitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Prefixes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProviderID",
                table: "Prefixes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MemoOptions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoOptions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthNote = table.Column<string>(nullable: true),
                    BenefitRenewal = table.Column<string>(nullable: true),
                    ContactID = table.Column<int>(nullable: true),
                    MiscNotes = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PagesToSave = table.Column<int>(nullable: false),
                    SavedPagesDescription = table.Column<string>(nullable: true),
                    SubscriberNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Providers_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stores_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProviderNotes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ProviderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderNotes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProviderNotes_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProviderNotes_Providers_ProviderID",
                        column: x => x.ProviderID,
                        principalTable: "Providers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Exam = table.Column<string>(nullable: true),
                    Frames = table.Column<string>(nullable: true),
                    Lenses = table.Column<string>(nullable: true),
                    ProviderNoteID = table.Column<int>(nullable: true),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patients_ProviderNotes_ProviderNoteID",
                        column: x => x.ProviderNoteID,
                        principalTable: "ProviderNotes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prefixes_ProviderID",
                table: "Prefixes",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ProviderNoteID",
                table: "Patients",
                column: "ProviderNoteID");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderNotes_ContactID",
                table: "ProviderNotes",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_ProviderNotes_ProviderID",
                table: "ProviderNotes",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_ContactID",
                table: "Providers",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_ContactID",
                table: "Stores",
                column: "ContactID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prefixes_Providers_ProviderID",
                table: "Prefixes",
                column: "ProviderID",
                principalTable: "Providers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prefixes_Providers_ProviderID",
                table: "Prefixes");

            migrationBuilder.DropTable(
                name: "MemoOptions");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "ProviderNotes");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Prefixes_ProviderID",
                table: "Prefixes");

            migrationBuilder.DropColumn(
                name: "ProviderID",
                table: "Prefixes");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Prefixes",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
