﻿namespace CleanArchitect.Services.UnitOfWorks;

public interface UnitOfWork
{
    void Save();
    Task Begin();
    Task Rollback();
    Task Commit();
}