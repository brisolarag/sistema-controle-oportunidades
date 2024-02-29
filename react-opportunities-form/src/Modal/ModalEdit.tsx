import { FC } from 'react';
import './modalEdit.css';

interface ModalEditProps {
  id:string 
  onClose: () => void;
}

const ModalEdit: FC<ModalEditProps> = ({ id, onClose }) => {
  return (
    <div className="modal-overlay-edit" onClick={onClose}>
      <div className="modal-edit" onClick={(e) => e.stopPropagation()}>
        <div className="modal-edit-content">
          {/* Conteúdo da modal */}
          <h2>Minha Modal</h2>
          <p>{id}</p>
        </div>
      </div>
    </div>
  );
};

export default ModalEdit;