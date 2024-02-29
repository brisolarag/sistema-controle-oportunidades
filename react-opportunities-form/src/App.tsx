import './App.css'
import Form from "./Form/Form"
import Table from './assets/Table/Table';



function App() {
  const handleSubmit = async (title: string, desc: string, type: string, link: string, money: string) => {``
    // Aqui você pode fazer o que quiser com os dados do formulário, como enviar para um servidor, armazenar no estado, etc.
    let moneyDouble: number;
    try {
      if (money.includes(',')) {
        moneyDouble = parseFloat(money.replace(',', '.'))
      } else {
        moneyDouble = parseFloat(money)
      }
      if (isNaN(moneyDouble)) {
        throw new Error('Invalid money format');
      }
    } catch (error) {
      console.log(error);
      moneyDouble = 0;
    }
    try {
      const response = await fetch("http://localhost:4652/opportunities", {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({ title,desc,type,link, money })
      })
  
      if (response.ok) {
        console.log('=> POST: ', 'Dados do formulário:', { title, desc, type, link, moneyDouble })
      } else {
        throw new Error('Err when sending a POST req.')
      } 
      
    } catch (err) {
      console.log(`Error: Cannot do a POST REQ: ${err}`)
    }

  };

  return (
    <>
      <div className="content">
        <div id="content-form">
          <h1>Add new Job Opportunity:</h1>
          <Form onSubmit={handleSubmit}/>
        </div>

        <div id="content-table">
          <Table />
        </div>
      </div>
    </>
  )
}

export default App
