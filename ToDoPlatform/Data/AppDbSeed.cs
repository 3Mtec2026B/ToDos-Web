using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoPlatform.Models;

namespace ToDoPlatform.Data;

public class AppDbSeed
{
    public AppDbSeed(ModelBuilder builder)
    {
        #region Popular dados de Perfil de Usuário
        List<IdentityRole> roles = new()
        {
            new IdentityRole()
            {
                Id = "22164d6a-40c4-4ee5-b408-90b41dde37c5",
                Name = "Administrador",
                NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole()
            {
                Id = "0298aec3-2f2a-479e-acb4-144422a15d7a",
                Name = "Usuário",
                NormalizedName = "USUÁRIO"
            },
        };
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Popular dados de Usuário
        List<AppUser> users = new()
        {
            new AppUser()
            {
                Id = "07c08a8c-48a4-4cde-b17f-7fedf5a95c79",
                Email = "gallojunior@gmail.com",
                NormalizedEmail = "GALLOJUNIOR@GMAIL.COM",
                UserName = "gallojunior@gmail.com",
                NormalizedUserName = "GALLOJUNIOR@GMAIL.COM",
                LockoutEnabled = false,
                EmailConfirmed = true,
                Name = "José Antonio Gallo Junior",
                ProfilePicture = "/img/users/07c08a8c-48a4-4cde-b17f-7fedf5a95c79.png"
            },
            new AppUser()
            {
                Id = "41e8ef46-4c13-43cb-9b7e-7222642df441",
                Email = "galloranger@gmail.com",
                NormalizedEmail = "GALLORANGER@GMAIL.COM",
                UserName = "galloranger@gmail.com",
                NormalizedUserName = "GALLORANGER@GMAIL.COM",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Name = "José Antonio Gallo Junior",
                ProfilePicture = "/img/users/41e8ef46-4c13-43cb-9b7e-7222642df441.png"
            }
        };
        foreach (var user in users)
        {
            PasswordHasher<IdentityUser> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<AppUser>().HasData(users);
        #endregion

        #region Popular Dados de Usuário Perfil
        List<IdentityUserRole<string>> userRoles = new()
        {
            new IdentityUserRole<string>()
            {
                UserId = users[0].Id,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>()
            {
                UserId = users[1].Id,
                RoleId = roles[1].Id
            },
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion

        #region Popular as Tarefas do usuário
        List<ToDo> toDos = new()
        {
            new ToDo()
            {
                Id = 1,
                Title = "Terminar os PTDs",
                Description = "Finalizar até 11/03",
                UserId = users[0].Id
            },
            new ToDo()
            {
                Id = 2,
                Title = "Preparar material de revisão de MVC",
                Description = "Preparar apostila para alunos de MVC",
                UserId = users[0].Id
            },
            new ToDo()
            {
                Id = 3,
                Title = "Ligar no SAAE",
                Description = "Solicitar conserto do hidrometro",
                UserId = users[1].Id
            },
        };
        builder.Entity<ToDo>().HasData(toDos);
        #endregion
    }
}
