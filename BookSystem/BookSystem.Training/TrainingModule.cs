using Autofac;
using BookSystem.Training.Contexts;
using BookSystem.Training.Repositories;
using BookSystem.Training.Services;
using BookSystem.Training.UnitOfWorks;
using System;

namespace BookSystem.Training
{
    public class TrainingModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public TrainingModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<TrainingDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<TrainingDbContext>().As<ITrainingDbContext>()
               .WithParameter("connectionString", _connectionString)
               .WithParameter("migrationAssemblyName", _migrationAssemblyName)
               .InstancePerLifetimeScope();



            builder.RegisterType<BookRepository>().As<IBookRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TrainingUnitOfWork>().As<ITrainingUnitOfWork>()
               .InstancePerLifetimeScope();

            builder.RegisterType<BookService>().As<IBookService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<AuthorService>().As<IAuthorService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }


    }
}
