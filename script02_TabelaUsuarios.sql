BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230320104557_MigracaoUsuario', N'7.0.3');
GO

COMMIT;
GO

