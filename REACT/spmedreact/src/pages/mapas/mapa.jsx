import { Map, Marker, GoogleApiWrapper, InfoWindow } from 'google-maps-react';
import React, { Component } from "react";
import axios from "axios";

class MapContainer extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaLocalizacoes: [],
            showingInfoWindow: false,
            marcadorAtivo: {},
            lugar: {},
        }
    };

    BuscarLocalizacoes = () => {
        axios("http://localhost:5000/api/localizacoes", {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    this.setState({ listaLocalizacoes: resposta.data });
                }
            }).catch(erro => console.log(erro))
    }

    cliqueMarcador = (props, marker) =>
        this.setState({
            lugar: props,
            marcadorAtivo: marker,
            showingInfoWindow: true
        });


    componentDidMount() {
        this.BuscarLocalizacoes()
    }

    render() {
        return (
            <div>
                <main>
                    <Map google={this.props.google} zoom={12}
                        initialCenter={{
                            lat: -23.53620139908343,
                            lng: -46.64622506172682
                        }}>

                        {

                            this.state.listaLocalizacoes.map((item) => {

                                return (
                                    <Marker onClick={this.cliqueMarcador}
                                        id={item.id}
                                        title={item.id}
                                        name={item.id}
                                        position={{ lat: item.latitude, lng: item.longitude }} />
                                )
                            })
                        }

                        <InfoWindow
                            marker={this.state.marcadorAtivo}
                            visible={this.state.showingInfoWindow}>
                            <div>
                                <h1 style={{ fontSize: 14, color: "#82C0D9" }}>{this.state.lugar.name}</h1>
                            </div>
                        </InfoWindow>

                    </Map>
                </main>
            </div>
        )
    }

}

export default GoogleApiWrapper({
    apiKey: ("AIzaSyDBAKlR7YNlROT-q03Ra_Qpl_n_NiQRmdQ")
})(MapContainer)