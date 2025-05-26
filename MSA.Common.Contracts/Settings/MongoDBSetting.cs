namespace MSA.Common.Contracts.Settings;

public class MongoDBSetting
{
    public string Host { get; init; }

    public string Port { get; init; }

    public string ConnectionString => $"mongodb://{Host}:{Port}";
}