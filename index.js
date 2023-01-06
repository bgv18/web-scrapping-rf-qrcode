const puppeteer = require('puppeteer')

function processarDados(dados){
    //salva no banco de dados
    console.log(JSON.stringify(dados))
}

let scrape = async () => {
  const browser = await puppeteer.launch({headless: true})
  const page = await browser.newPage()
  await page.goto('http://www.fazenda.pr.gov.br/nfce/qrcode?p=41181175901603000163650010000020121000099782|2|1|1|18164672BA83E18A4D031D888856DAA658C565CF')
  
  // Scrape
  const result = await page.evaluate(() => {
    const itens = []
    const qtdItens = []
    const totalNota = []
    const nota = {
        nome: itens,
        qtd: qtdItens,
        total: totalNota
    }
    document.querySelectorAll('td > span.txtTit2').forEach(item => itens.push(item.textContent))
    document.querySelectorAll('td > span.Rqtd').forEach(item => qtdItens.push(item.textContent.replace(/([^\d])+/gim, '')))
    document.querySelectorAll('#linhaTotal > span.totalNumb').forEach(item => totalNota.push(item.textContent))
    return nota
  });
  browser.close()
  return result
};
 
scrape().then((value) => {
    processarDados(value)
})
