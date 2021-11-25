using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Dominio.Models.Enum;

namespace UnipPim.Hotel.Relatorio
{
    public static class RelatorioFuncionario
    {
        public static string GerarRelatorioFuncionario(List<Funcionario> list, string path, string fileName)
        {
            try
            {
                using (var workbook = new XLWorkbook(path))
                {
                    var worksheet = workbook.Worksheets.Worksheet("Sheet1");
                    int i = 0;
                    foreach (var obj in list)
                    {
                        if (i == 0)
                        {
                            worksheet.Cell("A" + (1 + i)).Value = "Id";
                            worksheet.Cell("B" + (1 + i)).Value = "Nome Completo";
                            worksheet.Cell("C" + (1 + i)).Value = "Cpf";
                            worksheet.Cell("D" + (1 + i)).Value = "Nascimento";
                            worksheet.Cell("E" + (1 + i)).Value = "Cargo";
                            worksheet.Cell("F" + (1 + i)).Value = "Email";
                            worksheet.Cell("G" + (1 + i)).Value = "Telefone 1";
                            worksheet.Cell("H" + (1 + i)).Value = "Telefone 2";
                            worksheet.Cell("I" + (1 + i)).Value = "Telefone 3";
                            worksheet.Cell("J" + (1 + i)).Value = "Cep";
                            worksheet.Cell("K" + (1 + i)).Value = "Logradouro";
                            worksheet.Cell("L" + (1 + i)).Value = "Numero";
                            worksheet.Cell("M" + (1 + i)).Value = "Complemento";
                            worksheet.Cell("N" + (1 + i)).Value = "Refencia";
                            worksheet.Cell("O" + (1 + i)).Value = "Bairro";
                            worksheet.Cell("P" + (1 + i)).Value = "Cidade";                            
                        }
                        worksheet.Cell("A" + (2 + i)).Value = obj.Id;
                        worksheet.Cell("B" + (2 + i)).Value = obj.NomeCompleto;
                        worksheet.Cell("C" + (2 + i)).Value = obj.Cpf;
                        worksheet.Cell("D" + (2 + i)).Value = obj.Nascimento;
                        worksheet.Cell("E" + (2 + i)).Value = obj.Cargo.Nome;
                        worksheet.Cell("F" + (2 + i)).Value = obj.Emails.FirstOrDefault()?.EnderecoEmail;
                        worksheet.Cell("G" + (2 + i)).Value = obj.Telefones.FirstOrDefault(x => x.TelefoneTipo == TelefoneTipo.CELULAR).Ddd + " - " + obj.Telefones.FirstOrDefault(x=>x.TelefoneTipo == TelefoneTipo.CELULAR).Numero;
                        worksheet.Cell("H" + (2 + i)).Value = obj.Telefones.FirstOrDefault(x => x.TelefoneTipo == TelefoneTipo.COMERCIAL)?.Ddd + " - " + obj.Telefones.FirstOrDefault(x => x.TelefoneTipo == TelefoneTipo.COMERCIAL)?.Numero;
                        worksheet.Cell("I" + (2 + i)).Value = obj.Telefones.FirstOrDefault(x => x.TelefoneTipo == TelefoneTipo.RESIDENCIAL)?.Ddd + " - " + obj.Telefones.FirstOrDefault(x => x.TelefoneTipo == TelefoneTipo.RESIDENCIAL)?.Numero;
                        worksheet.Cell("J" + (2 + i)).Value = obj.Enderecos.FirstOrDefault().Cep;
                        worksheet.Cell("K" + (2 + i)).Value = obj.Enderecos.FirstOrDefault().Logradouro;
                        worksheet.Cell("L" + (2 + i)).Value = obj.Enderecos.FirstOrDefault().Numero;
                        worksheet.Cell("M" + (2 + i)).Value = obj.Enderecos.FirstOrDefault().Complemento;
                        worksheet.Cell("N" + (2 + i)).Value = obj.Enderecos.FirstOrDefault().Referencia;
                        worksheet.Cell("O" + (2 + i)).Value = obj.Enderecos.FirstOrDefault().Bairro;
                        worksheet.Cell("P" + (2 + i)).Value = obj.Enderecos.FirstOrDefault().Cidade;
                        i++;
                    }

                    workbook.Save();
                    return Path.Combine("/ReportSheets_Temp/", fileName);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
