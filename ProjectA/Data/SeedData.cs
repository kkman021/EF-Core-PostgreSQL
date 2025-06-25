using Microsoft.EntityFrameworkCore;
using ProjectA.Data;
using ProjectA.Models;

// 建立一個測試用的客戶資料
public class SeedData
{
    public static async Task Initialize(ProjectADbContext context)
    {
        // 確保資料庫已建立
        await context.Database.EnsureCreatedAsync();

        // 檢查資料庫中是否已有客戶資料
        if (await context.Clients.AnyAsync())
        {
            return; // 如果已有資料，則不需再次填充
        }

        // 新增測試資料
        var clients = new[]
        {
            new Client
            {
                Name = "測試客戶 1",
                Email = "test1@example.com",
                Description = "這是一個測試客戶",
                Phone = "0911-111-111"
            },
            new Client
            {
                Name = "測試客戶 2",
                Email = "test2@example.com",
                Description = "這是另一個測試客戶",
                Phone = "0922-222-222"
            }
        };

        await context.Clients.AddRangeAsync(clients);
        await context.SaveChangesAsync();

        // 重新加載客戶資料以確保每個客戶實體都被完整加載
        var client1 = await context.Clients.FindAsync(clients[0].Id);
        var client2 = await context.Clients.FindAsync(clients[1].Id);

        // 為客戶新增 Token
        if (client1 != null && client2 != null)
        {
            var tokens = new[]
            {
                new TokenManager
                {
                    TokenValue = "token123456",
                    ClientId = client1.Id,
                    Client = client1,
                    ExpiresAt = DateTime.UtcNow.AddDays(30)
                },
                new TokenManager
                {
                    TokenValue = "token654321",
                    ClientId = client2.Id,
                    Client = client2,
                    ExpiresAt = DateTime.UtcNow.AddDays(30)
                }
            };

            await context.TokenManagers.AddRangeAsync(tokens);
            await context.SaveChangesAsync();
        }
    }
}
