﻿using Dapper;
using Dominio.Objeto;
using System;
using System.Collections.Generic;
using System.Data;

namespace Repositorio.Repositorio
{
    public class RepositorioCliente
    {
        public void AdicionarCliente(Cliente cliente)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"INSERT INTO Cliente (endereco, telefone, data_inscricao) 
                               VALUES (@Endereco, @Telefone, @DataDeInscricao)";

                dbConnection.Execute(sql, new
                {
                    cliente.Endereco,
                    cliente.Telefone,
                    cliente.DataDeInscricao
                });
            }
        }

        public void AtualizarCliente(Cliente cliente)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = @"UPDATE Cliente 
                               SET endereco = @Endereco, telefone = @Telefone, data_inscricao = @DataDeInscricao 
                               WHERE cod_cliente = @Codigo";

                dbConnection.Execute(sql, new
                {
                    cliente.Codigo,
                    cliente.Endereco,
                    cliente.Telefone,
                    cliente.DataDeInscricao
                });
            }
        }

        public void DeletarCliente(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "DELETE FROM Cliente WHERE cod_cliente = @Codigo";

                dbConnection.Execute(sql, new { Codigo = id });
            }
        }

        public Cliente ObterClientePorId(int id)
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT * FROM Cliente WHERE cod_cliente = @Codigo";

                return dbConnection.QuerySingleOrDefault<Cliente>(sql, new { Codigo = id });
            }
        }

        public IList<Cliente> ObterTodosClientes()
        {
            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT * FROM Cliente";

                return dbConnection.Query<Cliente>(sql).AsList();
            }
        }

        public bool ExisteCliente(int codigo)
        {
            if (codigo <= 0) return false;

            using (IDbConnection dbConnection = ConfigBanco.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM Cliente WHERE id = @codigo";
                
                int count = dbConnection.ExecuteScalar<int>(sql, new { codigo });

                var existe = count == 1;

                return existe;
            }
        }
    }
}
