using Microsoft.EntityFrameworkCore.Migrations;

namespace OnikiMBussiness.Migrations
{
    public partial class spStok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            var sp = @"create proc stok2
(
	@malKodu nvarchar(30)
	
)
as
begin
			select ID, case when(IslemTur=0 ) then 'Giris'  when(IslemTur=1 ) then 'Cıkış' end as IslemTur,
			EvrakNo,Tarih,
			case when (IslemTur=1) then '0' else Miktar end as GirisMiktar  ,
			case when (IslemTur=0) then '0' else Miktar end as ÇıkışMiktar
			from STI
			where MalKodu =@malKodu

end";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STI");

            migrationBuilder.DropTable(
                name: "STK");
        }
    }
}
