import React, { useState } from 'react';
import './form.css';

interface FormProps {
    onSubmit: (title: string, desc: string, type: string, link: string, money: string) => void;
}

const Form: React.FC<FormProps> = ({ onSubmit }) => {
    const [title, setTitle] = useState('');
    const [desc, setDesc] = useState('');
    const [type, setType] = useState('');
    const [link, setLink] = useState('');
    const [money, setMoney] = useState('');

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        onSubmit(title, desc, type, link, money);
        // Limpar os campos do formulário após o envio
        setTitle('');
        setDesc('');
        setType('');
        setLink('');
        setMoney('');
    };

    return (
        
        <div className='form-container'>
            <form onSubmit={handleSubmit}>
                <div className='form-fields form-title'>
                    <label htmlFor="title">Title:</label>
                    <input
                        type="text"
                        id="title"
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                    />
                </div>
                <div className='form-fields form-desc'>
                    <label htmlFor="desc">Description:</label>
                    <textarea
                        id="desc"
                        value={desc}
                        onChange={(e) => setDesc(e.target.value)}
                    />
                </div>
                <div className='form-fields form-type'>
                    <label htmlFor="type">Type:</label>
                    <input
                        type="text"
                        id="type"
                        value={type}
                        onChange={(e) => setType(e.target.value)}
                    />
                </div>
                <div className='form-fields form-money'>
                    <label htmlFor="money">Money:</label>
                    <input
                        type="text"
                        id="money"
                        value={money}
                        onChange={(e) => setMoney(e.target.value)}
                        
                    />
                </div>
                <div className='form-fields form-link'>
                    <label htmlFor="link">Link:</label>
                    <input
                        type="text"
                        id="link"
                        value={link}
                        onChange={(e) => setLink(e.target.value)}
                    />
                </div>
                <button type="submit">Submit</button>
            </form>
        </div>
    );
}

export default Form;