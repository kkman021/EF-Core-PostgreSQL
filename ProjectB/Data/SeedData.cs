using Microsoft.EntityFrameworkCore;
using ProjectB.Data;
using ProjectB.Models;

// 建立測試用的郵件範本與簡訊設定資料
public class SeedData
{
    public static async Task Initialize(ProjectBDbContext context)
    {
        // 確保資料庫已建立
        await context.Database.EnsureCreatedAsync();

        // 檢查資料庫中是否已有郵件範本資料
        if (await context.MailTemplates.AnyAsync())
        {
            return; // 如果已有資料，則不需再次填充
        }

        // 新增測試郵件範本資料
        var mailTemplates = new[]
        {
            new MailTemplate
            {
                Name = "歡迎郵件",
                Subject = "歡迎加入我們的服務！",
                Body = "<p>親愛的客戶，</p><p>感謝您加入我們的服務。</p>",
                TemplateType = "Welcome"
            },
            new MailTemplate
            {
                Name = "密碼重設郵件",
                Subject = "密碼重設請求",
                Body = "<p>您好，</p><p>有人請求重設您的密碼，請點擊以下連結重設：</p><p>{ResetLink}</p>",
                TemplateType = "PasswordReset"
            }
        };

        await context.MailTemplates.AddRangeAsync(mailTemplates);

        // 新增測試簡訊設定資料
        var smsConfigs = new[]
        {
            new SMSConfig
            {
                ProviderName = "Twilio",
                ApiKey = "test_api_key_1",
                ApiSecret = "test_api_secret_1",
                SenderId = "TestSender"
            },
            new SMSConfig
            {
                ProviderName = "Nexmo",
                ApiKey = "test_api_key_2",
                ApiSecret = "test_api_secret_2",
                SenderId = "TestNexmo"
            }
        };

        await context.SMSConfigs.AddRangeAsync(smsConfigs);
        await context.SaveChangesAsync();
    }
}
