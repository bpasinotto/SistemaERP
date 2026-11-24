using System.Globalization;
using SistemaERP.Modelo;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;

namespace SistemaERP.Negocio;

public class VendaPdfServico
{
    private static readonly CultureInfo CulturaPtBr = new("pt-BR");

    /// <summary>
    /// Gera um comprovante de venda em PDF utilizando Syncfusion.Pdf.WinForms
    /// </summary>
    public void GerarComprovantePdf(Venda venda, string caminhoArquivo)
    {
        if (venda == null)
            throw new ArgumentNullException(nameof(venda));

        if (string.IsNullOrWhiteSpace(caminhoArquivo))
            throw new ArgumentException("Caminho do arquivo PDF inválido.", nameof(caminhoArquivo));

        using var document = new PdfDocument();
        document.PageSettings.Orientation = PdfPageOrientation.Portrait;
        document.PageSettings.Margins.All = 30;

        PdfPage page = document.Pages.Add();
        PdfGraphics graphics = page.Graphics;
        float pageWidth = page.GetClientSize().Width;

        // Cores padrão do sistema (Verde Petróleo RGB 2, 89, 89)
        var corPrimaria = new PdfColor(2, 89, 89);
        var corTexto = new PdfColor(35, 35, 35);
        var corCinzaClaro = new PdfColor(242, 245, 245);
        var corBorda = new PdfColor(180, 195, 195);
        var corCancelada = new PdfColor(168, 42, 42);

        var brushPrimaria = new PdfSolidBrush(corPrimaria);
        var brushBranco = new PdfSolidBrush(new PdfColor(255, 255, 255));
        var brushTexto = new PdfSolidBrush(corTexto);
        var brushCinza = new PdfSolidBrush(corCinzaClaro);
        var brushSituacao = string.Equals(venda.Situacao, "Cancelada", StringComparison.OrdinalIgnoreCase)
            ? new PdfSolidBrush(corCancelada)
            : brushPrimaria;

        var fonteTitulo = new PdfStandardFont(PdfFontFamily.Helvetica, 18, PdfFontStyle.Bold);
        var fonteSubtitulo = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Regular);
        var fonteSecao = new PdfStandardFont(PdfFontFamily.Helvetica, 11, PdfFontStyle.Bold);
        var fonteNormal = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Regular);
        var fonteNegrito = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);
        var fonteTotal = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);
        var fonteRodape = new PdfStandardFont(PdfFontFamily.Helvetica, 8, PdfFontStyle.Italic);

        float y = 0;

        // Cabeçalho
        graphics.DrawRectangle(brushPrimaria, new RectangleF(0, y, pageWidth, 58));
        graphics.DrawString("PasiWare ERP - Comprovante de Venda", fonteTitulo, brushBranco, new PointF(14, y + 10));
        graphics.DrawString(
            $"Venda Nº #{venda.Id}   |   Data: {venda.DataVenda.ToString("dd/MM/yyyy HH:mm", CulturaPtBr)}",
            fonteSubtitulo,
            brushBranco,
            new PointF(14, y + 36));

        var formatoDireita = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
        graphics.DrawString(
            $"Situação: {venda.Situacao.ToUpper(CulturaPtBr)}",
            fonteNegrito,
            brushBranco,
            new RectangleF(pageWidth - 200, y + 32, 186, 18),
            formatoDireita);

        y += 72;

        // Dados da Venda (Cliente e Vendedor)
        graphics.DrawRectangle(new PdfPen(corBorda, 0.75f), brushCinza, new RectangleF(0, y, pageWidth, 54));
        graphics.DrawString("Cliente:", fonteNegrito, brushTexto, new PointF(12, y + 10));
        graphics.DrawString($"{venda.IdCliente} - {venda.NomeCliente}", fonteNormal, brushTexto, new PointF(68, y + 10));

        graphics.DrawString("Vendedor:", fonteNegrito, brushTexto, new PointF(12, y + 30));
        graphics.DrawString(venda.NomeUsuario, fonteNormal, brushTexto, new PointF(68, y + 30));

        graphics.DrawString("Situação:", fonteNegrito, brushTexto, new PointF(pageWidth - 180, y + 10));
        graphics.DrawString(venda.Situacao, fonteNegrito, brushSituacao, new PointF(pageWidth - 122, y + 10));

        y += 68;

        // Título da seção de itens
        graphics.DrawString("Itens da Venda", fonteSecao, brushPrimaria, new PointF(0, y));
        y += 18;

        // Grade de itens
        var pdfGrid = new PdfGrid();
        pdfGrid.Columns.Add(6);

        pdfGrid.Columns[0].Width = pageWidth * 0.10f; // Cód.
        pdfGrid.Columns[1].Width = pageWidth * 0.38f; // Descrição
        pdfGrid.Columns[2].Width = pageWidth * 0.08f; // UN
        pdfGrid.Columns[3].Width = pageWidth * 0.12f; // Qtd.
        pdfGrid.Columns[4].Width = pageWidth * 0.16f; // Preço Unit.
        pdfGrid.Columns[5].Width = pageWidth * 0.16f; // Subtotal

        PdfGridRow header = pdfGrid.Headers.Add(1)[0];
        header.Cells[0].Value = "Cód.";
        header.Cells[1].Value = "Descrição";
        header.Cells[2].Value = "UN";
        header.Cells[3].Value = "Qtd.";
        header.Cells[4].Value = "Preço Unit.";
        header.Cells[5].Value = "Subtotal";

        var estiloHeader = new PdfGridCellStyle
        {
            BackgroundBrush = brushPrimaria,
            TextBrush = brushBranco,
            Font = fonteNegrito
        };
        estiloHeader.Borders.All = new PdfPen(corPrimaria, 0.5f);

        for (int i = 0; i < header.Cells.Count; i++)
        {
            header.Cells[i].Style = estiloHeader;
            if (i >= 3)
            {
                header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
            }
            else if (i == 0 || i == 2)
            {
                header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
            }
            else
            {
                header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            }
        }

        pdfGrid.Style.CellPadding = new PdfPaddings(5, 5, 5, 5);
        pdfGrid.Style.Font = fonteNormal;

        var penGrade = new PdfPen(corBorda, 0.5f);

        for (int idx = 0; idx < venda.Itens.Count; idx++)
        {
            var item = venda.Itens[idx];
            PdfGridRow row = pdfGrid.Rows.Add();
            row.Cells[0].Value = item.IdProduto.ToString(CulturaPtBr);
            row.Cells[1].Value = item.NomeProduto;
            row.Cells[2].Value = item.Un;
            row.Cells[3].Value = item.Quantidade.ToString("0.###", CulturaPtBr);
            row.Cells[4].Value = item.ValorUnitario.ToString("C2", CulturaPtBr);
            row.Cells[5].Value = item.ValorTotalItem.ToString("C2", CulturaPtBr);

            var cellStyle = new PdfGridCellStyle
            {
                BackgroundBrush = idx % 2 == 1 ? brushCinza : brushBranco,
                TextBrush = brushTexto,
                Font = fonteNormal
            };
            cellStyle.Borders.All = penGrade;

            for (int c = 0; c < row.Cells.Count; c++)
            {
                row.Cells[c].Style = cellStyle;
                if (c >= 3)
                {
                    row.Cells[c].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
                }
                else if (c == 0 || c == 2)
                {
                    row.Cells[c].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
                }
                else
                {
                    row.Cells[c].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                }
            }
        }

        var layoutFormat = new PdfGridLayoutFormat { Layout = PdfLayoutType.Paginate };
        PdfLayoutResult gridResult = pdfGrid.Draw(page, new PointF(0, y), layoutFormat);

        PdfPage ultimaPagina = gridResult.Page;
        PdfGraphics lastGraphics = ultimaPagina.Graphics;
        float posY = gridResult.Bounds.Bottom + 16;

        // Verifica espaço restante na página para o bloco de Total + Observação
        float alturaNecessaria = string.IsNullOrWhiteSpace(venda.Observacao) ? 70 : 140;
        if (posY + alturaNecessaria > ultimaPagina.GetClientSize().Height)
        {
            ultimaPagina = document.Pages.Add();
            lastGraphics = ultimaPagina.Graphics;
            posY = 10;
        }

        // Total Geral
        lastGraphics.DrawRectangle(new PdfPen(corPrimaria, 1f), brushCinza, new RectangleF(pageWidth - 230, posY, 230, 36));
        lastGraphics.DrawString(
            $"TOTAL GERAL: {venda.ValorTotal.ToString("C2", CulturaPtBr)}",
            fonteTotal,
            brushPrimaria,
            new RectangleF(pageWidth - 224, posY, 218, 36),
            formatoDireita);

        posY += 50;

        // Observação (quando preenchida)
        if (!string.IsNullOrWhiteSpace(venda.Observacao))
        {
            lastGraphics.DrawString("Observações:", fonteSecao, brushPrimaria, new PointF(0, posY));
            posY += 16;

            var rectObs = new RectangleF(0, posY, pageWidth, 55);
            lastGraphics.DrawRectangle(new PdfPen(corBorda, 0.75f), brushCinza, rectObs);
            lastGraphics.DrawString(
                venda.Observacao.Trim(),
                fonteNormal,
                brushTexto,
                new RectangleF(8, posY + 6, pageWidth - 16, 44));
            posY += 66;
        }

        // Rodapé
        float footerY = ultimaPagina.GetClientSize().Height - 16;
        lastGraphics.DrawLine(new PdfPen(corBorda, 0.5f), new PointF(0, footerY - 6), new PointF(pageWidth, footerY - 6));
        lastGraphics.DrawString(
            $"Documento gerado em {DateTime.Now.ToString("dd/MM/yyyy HH:mm", CulturaPtBr)} - PasiWare ERP",
            fonteRodape,
            brushTexto,
            new PointF(0, footerY));

        using var stream = new FileStream(caminhoArquivo, FileMode.Create, FileAccess.Write);
        document.Save(stream);
    }
}

