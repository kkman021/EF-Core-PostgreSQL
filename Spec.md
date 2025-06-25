我要建立兩個 .net Web API 專案實踐 POC，裡面需要使用 Entity Framework Core 實踐。
A 專案有： Client、TokenMangaer 兩張表
B 專案有： MailTemplate、SMSConfig 兩張表
A、B 專案共用一個資料庫，並且都要獨立對該資料庫進行 Migration 的行為，資料庫請用 MS SQL LocalDB。
請協助我設計