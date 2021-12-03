import React from 'react';

import {
    Image,
    StatusBar,
    StyleSheet,
    View,
} from 'react-native'

import { createMaterialTopTabNavigator } from '@react-navigation/material-top-tabs';

import Consulta from './listar'

const BottomTab = createMaterialTopTabNavigator();

export default function Main() {
    return(
        <View
            style={styles.main}
        >
            <StatusBar
                hidden={false}
            />
            <BottomTab.Navigator
                initialRouteName='Consulta'
                screenOptions={({route}) => ({
                    tabBarIcon: () => {
                        if (route.name === 'Logout') {
                            return(
                                <Image
                                    source={require('../../assets/img/LogoutIcon.png')}
                                    style={styles.tabBarLog}
                                />
                            )
                        }
                        if (route.name === 'Perfil') {
                            return(
                                <Image
                                    source={require('../../assets/img/PerfilIcon.png')}
                                    style={styles.tabBarPerfil}
                                />
                            )
                        }
                        if (route.name === 'Consulta') {
                            return(
                                <Image
                                    source={require('../../assets/img/ConsultaIcon.png')}
                                />
                            )
                        }
                    },
                    headerShown: false,
                    tabBarShowLabel: false,
                    swipeEnabled​: true,
                    tabBarActiveBackgroundColor: '#118E8E',
                    tabBarInactiveBackgroundColor: '#0F6A6A',
                    tabBarPosition​: 'bottom',
                    tabBarStyle: { height: 70 }
                })}
            >
                <BottomTab.Screen name="Logout"/>
                <BottomTab.Screen name="Perfil"/>
                <BottomTab.Screen name="Consulta" component={Consulta}/>
            </BottomTab.Navigator>
        </View>
    )
}

const styles = StyleSheet.create({
    main: {
        flex: 1,
        backgroundColor: '#118E8E'
    },
    tabBarLog:{
        width:32,
        height:30
    },
    tabBarPerfil:{
        width:25,
        height:29,
    },
    tabBarConsulta:{
        width:35,
        height:30,
    }

})