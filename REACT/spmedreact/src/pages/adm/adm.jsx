import { useState, useEffect } from 'react';
import axios from "axios";

import Header from "../../components/header/header";
import Footer from '../../components/footer/footer';

import '../../assets/css/adm.css'

export default function ConsultaAdm() {
    const [listaConsul, setListaConsul] = useState([]);
    const [idPaciente, setIdPaciente] = useState('');
    const [idMedico, setIdMedico] = useState('');
    const [dataConsul, setDataConsul] = useState('');
    const [isLoading, setIsLoading] = useState(false);

    function listarConsultas() {
        axios('http://spmedgroup-kaue.azurewebsites.net/api/consultas', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaConsul(resposta.data)
                }
            })

            .catch(erro => console.log(erro))
    };

    useEffect(listarConsultas, []);

    function cadastrarConsulta(evento) {
        setIsLoading(true);

        evento.preventDefault()

        axios
            .post('http://spmedgroup-kaue.azurewebsites.net/api/consultas', {
                idPaciente: idPaciente,
                idMedico: idMedico,
                dataConsul: dataConsul
            }, {
                headers: {
                    'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
                }
            })
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log('Consulta cadastrada');
                    setIdMedico('');
                    setIdPaciente('');
                    setDataConsul('');
                    listarConsultas();
                    setIsLoading(false);
                }
            })
            .catch(erro => console.log(erro), setIdMedico(''), setIdPaciente(''), setDataConsul(''), setInterval(() => {
                setIsLoading(false)
            }, 5000));
    }

    return (
        <div>
            <Header />
            <main className="container">
                <div className="background_cadastrar">
                    <div className="grid alinhar_box">
                        <section className="container_form">
                            <form onSubmit={cadastrarConsulta} className="alinhar_form" onsubmit>
                                <h1>Cadastrar Consultas</h1>
                                <div className="container_input espacamento">
                                    <label htmlFor="paciente">Paciente</label>
                                    <select
                                        name="paciente" 
                                        id="paciente"
                                        value={idPaciente}
                                        onChange = {(campo) => setIdPaciente(campo.target.value)}
                                    >
                                        <option value="0">Selecione o Id do Paciente</option>
                                        
                                        {listaConsul.map((pacientes) => {
                                            
                                        })}

                                    </select>
                                </div>
                                <div className="container_input">
                                    <label htmlFor="medico">Médico</label>
                                    <select name="medico" id="medico" />
                                </div>
                                <div className="container_input">
                                    <label htmlFor="data">Data</label>
                                    <input type="date" name="data" />
                                </div>
                                <button className="btn">Cadastrar</button>
                            </form>
                        </section>
                    </div>
                </div>
                <div className="background_consulta">
                    <div className="grid alinhar_consulta">
                        <section className="container_tabela">
                            <h2>Consultas Agendadas</h2>
                            <table className="tabela">
                                <thead>
                                    <tr>
                                        <th>Médico</th>
                                        <th>Paciente</th>
                                        <th>Descrição</th>
                                        <th>Data</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Keiji</td>
                                        <td>Lucas</td>
                                        <td>Apresenta comportamento raivoso</td>
                                        <td>11/11/21</td>
                                    </tr>
                                </tbody>
                            </table>
                        </section>
                    </div>
                </div>
            </main>
            <Footer />
        </div>
    )
}
