import {useEffect, useState} from 'react'
import './Table.css'
import ModalEdit from '../../Modal/ModalEdit';
import ModalStatus from '../../Modal/ModalStatus';

interface Opportunity {
    id: string;
    title: string;
    desc: string;
    type: string;
    link: string;
    money: number;
    status: string;
    dateChanged: string;
  }
const Table = () => {
  // modal => edit
  const [isModalEditOpen, setIsModalEditOpen] = useState(false);
  const [modalEditId, setModalEditId] = useState('');

  const openModalEdit = (id: string) => {
    setModalEditId(id);
    setIsModalEditOpen(true);
  };

  const closeModalEdit = () => {
    setIsModalEditOpen(false);
  };
  // modal => edit (end)

  // modal => status
  const [isModalStatusOpen, setIsModalStatusOpen] = useState(false);
  const [modalStatusId, setStatusEditId] = useState('');
  const [modalStatusStr, setStatusEditStr] = useState('');

  const openModalStatus = (id: string, status:string) => {
    setStatusEditId(id);
    setStatusEditStr(status)
    setIsModalStatusOpen(true);
  };

  const closeModalStatus = () => {
    setIsModalStatusOpen(false);
  };
  //modal => status (end)

  

    const [opData, setOpData] = useState<Opportunity[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
              const response = await fetch('http://localhost:4652/opportunities');
              if (response.ok) {
                const jsonData = await response.json();
                setOpData(jsonData); // Armazena os dados no estado
              } else {
                throw new Error('Erro ao obter os dados');
              }
            } catch (error) {
              console.error('Erro ao obter os dados:', error);
            }
          };
      
          fetchData();
        }, []);

        const handleClick = async (id: string) => {
            try {
              const response = await fetch(`http://localhost:4652/opportunities/${id}`, {
                method: 'DELETE',
                headers: {
                  'Content-Type': 'application/json'
                }
              });
        
              if (response.ok) {
                console.log(`Opportunity with ID ${id} deleted successfully`);
                setOpData(prevData => prevData.filter(item => item.id !== id));
              } else {
                throw new Error('Erro ao excluir a oportunidade');
              }
            } catch (error) {
              console.error('Erro ao excluir a oportunidade:', error);
            }
          };

  return (
    <>
        <div className='table-container'>
        <div className="table-table">
            {opData.map((item, index) => (
            <div className="table-content" key={index}>
                <div className="field-title table-field"><p>{item.title}</p></div>
                <div className="field-desc table-field"><button onClick={() => console.log(item.desc)}>view description</button></div>
                <div className="field-type table-field"><p>{item.type}</p></div>
                <div className="field-link table-field"><a href={item.link} target='_blank'>Link</a></div>
                <div className="field-status table-field"><p>{item.status}</p></div>
                <div className="field-dateChanged table-field"><p>{item.dateChanged}</p></div>
                <div className="table-btns">
                    <div className="table-btns-upper">
                        <button className='btn-x' onClick={() => handleClick(item.id)}>x</button>
                        <button className='btn-edit' onClick={() => openModalEdit(item.id)}>edit</button>
                    </div>
                    <div className="table-btns-down">
                        <button className='btn-status' onClick={() => openModalStatus(item.id, item.status)}>status</button>
                    </div>
                </div>
            </div>
            ))}
        </div>
        </div>
        
        {isModalEditOpen && <ModalEdit id={modalEditId} onClose={closeModalEdit} />}
        {isModalStatusOpen && <ModalStatus id={modalStatusId} status={modalStatusStr} onClose={closeModalStatus} />}
    </>
  );
};

export default Table