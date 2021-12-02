import React, {useState, useEffect} from 'react';
import {
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
  Image,
  ImageBackground,
  TextInput,
} from 'react-native';

import AsyncStorage from '@react-native-async-storage/async-storage';
import { useNavigation } from "@react-navigation/native";

import api from '../services/api';

export default function Login() {
    const [email, setEmail] = useState('');
    const [senha, setSenha] = useState('');
    const navigation = useNavigation()

    realizarLogin = async() => {
        console.warn('Login Iniciado')

        const resposta = await api.post('/Login', {
            email: email,
            senha: senha,
        });

        console.warn('Requisição Feita')

        const token = resposta.data.token;
        console.warn(token)
        await AsyncStorage.setItem('userToken', token)

        if (resposta.status == 200) {
            console.warn('Redirecionando')
            navigation.navigate('Main')
        }
    };

    return(
        <ImageBackground
            source={require('../../assets/img/LoginBack.png')}
            style={StyleSheet.absoluteFillObject}
        >
            <View style={styles.main}>
                <Image
                    source={require('../../assets/img/LoginIcon.png')}
                    style={styles.mainImgLogin}
                />
                <TextInput
                    placeholder='Email'
                    placeholderTextColor='#FFF'
                    keyboardType='email-address'
                    value={email}
                    onChange={(campo) => setEmail(campo)}
                    style={styles.inputLogin}
                />
                <TextInput
                    placeholder='Senha'
                    placeholderTextColor='#FFF'
                    keyboardType='default'
                    secureTextEntry={true}
                    value={senha}
                    onChange={(campo) => setSenha(campo)}
                    style={styles.inputLogin}
                />
                <TouchableOpacity
                    onPress={realizarLogin}
                    style={styles.btnLogin}
                >
                    <Text
                        style={styles.btnLoginText}
                    >
                        Login
                    </Text>
                </TouchableOpacity>
            </View>
        </ImageBackground>
    )
}

const styles = StyleSheet.create({
    main: {
        justifyContent:'center',
        alignItems:'center',
        width:'100%',
        height:'100%',
    },
    mainImgLogin:{
        height:100,
        width:165,
        margin:60,
        marginTop:0,
    },
    inputLogin:{
        width:280,
        marginBottom:40,
        textTransform:'uppercase',
        fontFamily:'TitilliumWeb-Regular',
        fontSize:16,
        borderBottomColor: '#FFF',
        borderBottomWidth:2,
    },
    btnLoginText:{
        fontSize:16,
        fontFamily:'TitilliumWeb-Regular',
        color: '#FFF',
        textTransform:'uppercase',
        letterSpacing:6,
    },
    btnLogin:{
        alignItems: 'center',
        justifyContent: 'center',
        height:47,
        width:80,
        borderColor: '#FFF',
        borderWidth:2,
        shadowOffset:{height:1, width:1}
    }
})