import { useState, useEffect } from 'react';
import axios from "axios";

import Header from "../../components/header/header";
import Footer from '../../components/footer/footer';

import '../../assets/css/med.css'

export default function ConsultaAdm() {
    const [listaConsul, setListaConsul] = useState([]);
    const [listaMed, setListaMed] = useState([]);
    const [listaPac, setListaPac] = useState([]);
    const [idPaciente, setIdPaciente] = useState('');
    const [idMedico, setIdMedico] = useState('');
    const [dataConsul, setDataConsul] = useState('');
    const [isLoading, setIsLoading] = useState(false);

    function listarConsultas() {
        axios('http://spmedgroup-kaue.azurewebsites.net/api/consultas/minhas', {
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

    function listarMedicos() {
        axios('http://spmedgroup-kaue.azurewebsites.net/api/medicos', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaMed(resposta.data)
                }
            })

            .catch(erro => console.log(erro))
    }

    useEffect(listarMedicos, []);

    function listarPacientes() {
        axios('http://spmedgroup-kaue.azurewebsites.net/api/pacientes', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaPac(resposta.data)
                }
            })

            .catch(erro => console.log(erro))
    }

    useEffect(listarPacientes, []);

    function alterarConsulta(evento) {
        setIsLoading(true);

        evento.preventDefault()

        axios
            .patch('http://spmedgroup-kaue.azurewebsites.net/api/consultas', {
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
            <Header/>
            <main className="container">
                <div className="background_cadastrar">
                    <div className="grid alinhar_box">
                        <section className="container_form">
                            <form className="alinhar_form" onsubmit>
                                <h1>Alterar Prontuário</h1>
                                <div className="container_input espacamento">
                                    <label htmlFor="consulta">Consulta</label>
                                    <select name="consulta" id="consulta" />
                                </div>
                                <div className="container_input">
                                    <label htmlFor="descricao">Descrição</label>
                                    <input type="text" name="descricao" />
                                </div>
                                <button className="btn">Alterar</button>
                            </form>
                        </section>
                    </div>
                </div>
                <div className="background_consulta">
                    <div className="grid alinhar_consulta">
                        <section className="container_tabela">
                            <h2>Minhas Consultas</h2>
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
            <Footer/>
        </div>
    )
}