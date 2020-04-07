    import React, { Component } from 'react';
    import axios from 'axios';

    export class FormTest extends Component {
        constructor(props) {
            super(props);

            this.state = {
                starSystemName: "",
                starSystemLocation:"",         
                shipName: "",
                shipType: "",
                shipMaxCrew:""
            };

            this.handleStarSystemName = this.handleStarSystemName.bind(this);
            this.handleStarSystemLocation = this.handleStarSystemLocation.bind(this);
            this.handleShipName = this.handleShipName.bind(this);
            this.handleShipType = this.handleShipType.bind(this);
            this.handleShipMaxCrew = this.handleShipMaxCrew.bind(this);
            this.handleSubmit = this.handleSubmit.bind(this);
        }

        handleStarSystemName(event) {
            this.setState({              
                        starSystemName: event.target.value 
            });
        
        }
        handleStarSystemLocation(event) {
            console.log(event.target.value)
            this.setState({
                    starSystemLocation: event.target.value
            });
        }
        handleShipName(event) {
            this.setState({
                    shipName: event.target.value
            });
        }  
        handleShipType(event) {
            this.setState({
                    shipType: event.target.value
            });
        }
        handleShipMaxCrew(event) {
            this.setState({
                    shipMaxCrew: event.target.value
            });
        }
        handleSubmit = (e) => {
            console.log(this.state.starSystemName)
            console.log(this.state.starSystemLocation)
            e.preventDefault();       
            const data = new FormData();
            data.append("starSystem.Name", this.state.starSystemName);
            data.append("starSystem.Location", this.state.starSystemLocation);
            data.append("ship.Name", this.state.shipName);
            data.append("ship.Type", this.state.shipType);
            data.append("ship.MaxCrew", this.state.shipMaxCrew);
            console.log(data);
       
            axios({
                method: 'post',
                url: 'https://localhost:44301/WeatherForecast',
                data: data,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
        render() {
            return (
                <div id="newGameForm" >
                    <form id="myForm" onSubmit={this.handleSubmit}>
                        <input type="text" value={this.state.starSystemName} placeholder="Enter star system name:" onChange={this.handleStarSystemName} />
                        <input type="text" value={this.state.starSystemLocation} placeholder="Enter star system location:" onChange={this.handleStarSystemLocation} />
                        <input type="text" value={this.state.shipName} placeholder="Enter ship name:" onChange={this.handleShipName} />
                        <input type="text" value={this.state.shipType} placeholder="Enter ship type:" onChange={this.handleShipType} />
                        <input type="text" value={this.state.shipMaxCrew} placeholder="Enter max crew:" onChange={this.handleShipMaxCrew}/>  
                        <button type="submit">Submit</button>
                    </form>
                </div >
            )
        }
    }