import { FC, useState } from 'react';
import './modalStatus.css';

interface ModalStatusProps {
  id:string 
  status: string
  onClose: () => void;
}

const ModalStatus: FC<ModalStatusProps> = ({ id, status, onClose }) => {
  const [selectedOption, setSelectedOption] = useState(status);

  const handleOptionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSelectedOption(event.target.value);
  };

  const handleSubmit = async () => {
    const selectedLower = selectedOption.toLowerCase();
    try {
      const response = await fetch(`http://localhost:4652/opportunities/${selectedLower}/${id}`, {
        method: 'PUT', // Alterado para PUT
        headers: {
          'Content-Type': 'application/json'
        },
      });
  
      if (response.ok) {
        console.log('Requisição bem-sucedida');
      } else {
        throw new Error('Erro ao fazer a requisição');
      }
    } catch (error) {
      console.error('Erro ao fazer a requisição:', error);
    }
  
    console.log('Opção selecionada:', selectedLower);
    onClose(); // Feche a modal após a submissão
  };



  return (
    <div className="modal-overlay-status" onClick={onClose}>
      <div className="modal-status" onClick={(e) => e.stopPropagation()}>
        <h3>Change the job opportunity status:</h3>
        <p>id: {id}</p>
        <div className="modal-status-content">
          <div className="modal-status-radios">

            

            <div>
                <label >
                <input
                    type="radio"
                    value="NAplicado"
                    checked={selectedOption === 'NAplicado'}
                    onChange={handleOptionChange}
                />
                NAplicado
                </label>
            </div>
            <div>
                <label>
                <input
                    type="radio"
                    value="Aplicado"
                    checked={selectedOption === 'Aplicado'}
                    onChange={handleOptionChange}
                />
                Aplicado
                </label>
            </div>
            <div>
                <label>
                <input
                    type="radio"
                    value="EntMarcada"
                    checked={selectedOption === 'EntMarcada'}
                    onChange={handleOptionChange}
                />
                EntMarcada
                </label>
            </div>
            <div>
                <label>
                <input
                    type="radio"
                    value="Aprovado"
                    checked={selectedOption === 'Aprovado'}
                    onChange={handleOptionChange}
                />
                Aprovado
                </label>
            </div>
            <div>
                <label>
                <input
                    type="radio"
                    value="NAprovado"
                    checked={selectedOption === 'NAprovado'}
                    onChange={handleOptionChange}
                />
                NAprovado
                </label>
            </div>


          </div>
        <button onClick={handleSubmit}>Enviar</button>
        </div>
      </div>
    </div>
  );
};

export default ModalStatus;