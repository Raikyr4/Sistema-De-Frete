﻿using Dapper;
using Dominio.Objeto;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repositorio.Repositorio
{
    public class RepositorioPessoaFisica
    {
        public void AdicionarPessoaFisica(PessoaFisica pessoaFisica)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"INSERT INTO PessoaFisica (nome, cpf, cod_representante) 
                               VALUES (@Nome, @CPF, @CodigoDoRepresentante)";

                dbConnection.Execute(sql, new
                {
                    pessoaFisica.Nome,
                    pessoaFisica.CPF,
                    pessoaFisica.CodigoDoRepresentante
                });
            }
        }

        public void AtualizarPessoaFisica(PessoaFisica pessoaFisica)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"UPDATE PessoaFisica 
                               SET nome = @Nome, cpf = @CPF, cod_representante = @CodigoDoRepresentante 
                               WHERE cod_PessoaFisica = @Codigo";

                dbConnection.Execute(sql, new
                {
                    pessoaFisica.Codigo,
                    pessoaFisica.Nome,
                    pessoaFisica.CPF,
                    pessoaFisica.CodigoDoRepresentante
                });
            }
        }

        public void DeletarPessoaFisica(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "DELETE FROM PessoaFisica WHERE cod_PessoaFisica = @Codigo";

                dbConnection.Execute(sql, new { Codigo = id });
            }
        }

        public PessoaFisica ObterPessoaFisicaPorId(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT * FROM PessoaFisica WHERE cod_PessoaFisica = @Codigo";

                return dbConnection.QuerySingleOrDefault<PessoaFisica>(sql, new { Codigo = id });
            }
        }

        public IList<PessoaFisica> ObterTodasPessoasFisicas()
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT * FROM PessoaFisica";

                return dbConnection.Query<PessoaFisica>(sql).AsList();
            }
        }
        public bool ExistePessoaFisica(string cpf)
        {
            if (cpf.Length < 14  || cpf.Length > 14) return false;

            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM PessoaFisica WHERE cpf = @cpf";
                
                int count = dbConnection.ExecuteScalar<int>(sql, new { cpf });

                var existe = count == 1;

                return existe;
            }
        }

    }
}