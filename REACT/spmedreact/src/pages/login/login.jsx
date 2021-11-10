import { Component } from 'react';
import axios from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link } from 'react-router-dom';

import Header from '../../components/header/header'
import Footer from '../../components/footer/footer'

import '../../assets/css/login.css'

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
            erroMensagem: '',
            isLoading: false,
        };
    }


    efetuaLogin = (evento) => {
        evento.preventDefault();

        this.setState({ erroMensagem: '', isLoading: true })

        axios
            .post('http://spmedgroup-kaue.azurewebsites.net/api/login', {
                email: this.state.email,
                senha: this.state.senha,
            })

            .then((resposta) => {
                if (resposta.status === 200) {
                    localStorage.setItem('usuario-login', resposta.data.token);

                    this.setState({ isLoading: false });

                    let base64 = localStorage.getItem('usuario-login').split[1];

                    console.log(base64)

                    console.log(this.props);

                    if (parseJwt().role === '1') {
                        this.props.history.push('/pac')
                    }
                    else if (parseJwt().role === '2') {
                        this.props.history.push('/adm')
                        console.log(`estou logado: ${usuarioAutenticado()}`)
                    }
                    else {
                        this.props.history.push('/med')
                    }
                }
            })

            .catch(() => {
                this.setState({
                    erroMensagem: 'Email ou senha inválidos',
                    isLoading: false,
                });
            });
    };

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    }

    render() {
        return (
            <div>
                <Header/>
                <main className="background">
                    <div className="grid">
                        <section className="container_form">
                            <form className="alinhar_form" onSubmit = {this.efetuaLogin}>
                                <h1>Login</h1>
                                <div className="container_input espacamento">
                                    <label for="email">Email</label>
                                    <input type="email"
                                        placeholder="Email"
                                        name="email"
                                        value = {this.state.email}
                                        onChange = {this.atualizaStateCampo}
                                    />
                                </div>
                                <div className="container_input">
                                    <label for="senha">Senha</label>
                                    <input type="password"
                                        placeholder="Senha"
                                        name="senha"
                                        value = {this.state.senha}
                                        onChange = {this.atualizaStateCampo}
                                    />
                                </div>
                                <div>
                                    
                                </div>
                                <button className="btn">Entrar</button>
                            </form>
                        </section>
                    </div>
                </main>
                <Footer/>
            </div>
        )
    }

}