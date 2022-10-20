// import * as THREE from 'https://cdn.skypack.dev/three@v0.122.0';


// Helper functions
// const rgb = function(r, g, b) {
//     return new THREE.Vector3(r, g, b);
// }
// const randomInteger = function(min, max) {
//     return Math.floor(Math.random() * (max - min + 1)) + min;
// }
// -- End Helper Functions

export const carouselTarjets = (arrayConfigs) => {
    console.log("🚀 ~ file: carouselTarjets.js ~ line 14 ~ carouselTarjets ~ arrayConfigs", arrayConfigs)

    setTimeout(() => {
        arrayConfigs.forEach(configCarousel => {
    
    
            // Get items
            const el = document.querySelector(configCarousel.individualItem);
            const elWidth = 
                parseFloat(window.getComputedStyle(el).width) + 
                parseFloat(window.getComputedStyle(el).marginLeft) + 
                parseFloat(window.getComputedStyle(el).marginRight)
            
            console.log("🚀 ~ file: carouselTarjets.js ~ line 24 ~ carouselTarjets ~ elWidth", elWidth)
    
            // Track carousel
            let mousedown = false;
            let movement = false;
            let initialPosition = 0;
            let selectedItem;
            let currentDelta = 0;
    
            document.querySelectorAll(configCarousel.carouselId).forEach(function(item) { 
                item.style.width = `${configCarousel.carouselWidth}px`;
            });
    
            document.querySelectorAll(configCarousel.carouselId).forEach(function(item) {
                item.addEventListener('pointerdown', function(e) {
                    
                    mousedown = true;
                    selectedItem = item;
                    initialPosition = e.pageX;
                    currentDelta = parseFloat(
                        item.querySelector(
                            configCarousel.carouselHolderId
                        ).style.transform.split('translateX(')[1]
                    ) || 0;
                }); 
            });
    
            const scrollCarousel = function(change, currentDelta, selectedItem) {
                let numberThatFit = Math.floor(configCarousel.carouselWidth / elWidth);
                let newDelta = currentDelta + change;
                let elLength = selectedItem.querySelectorAll(configCarousel.individualItem).length - numberThatFit;
                if(newDelta <= 0 && newDelta >= -elWidth * elLength) {
                    selectedItem.querySelector(configCarousel.carouselHolderId).style.transform = `translateX(${newDelta}px)`;
                } else {
                    if(newDelta <= -elWidth * elLength) {
                        selectedItem.querySelector(configCarousel.carouselHolderId).style.transform = `translateX(${-elWidth * elLength}px)`;
                    } else if(newDelta >= 0) {
                        selectedItem.querySelector(configCarousel.carouselHolderId).style.transform = `translateX(0px)`;
                    }
                }
            }
    
            document.body.addEventListener('pointermove', function(e) {
                
                // console.log("PASA POR ACA AL MOVER EL MOUSE")
             
                if(mousedown == true && typeof selectedItem !== "undefined") {
                    let change = -(initialPosition - e.pageX);
                    scrollCarousel(change, currentDelta, document.body);
                    document.querySelectorAll(`${configCarousel.carouselId} a`).forEach(function(item) {
                        item.style.pointerEvents = 'none';
                    });
                    movement = true;
                }
            });
    
            ['pointerup', 'mouseleave'].forEach(function(item) {
    
                document.body.addEventListener(item, function(e) {
                    selectedItem = undefined;
                    movement = false;
                    document.querySelectorAll(`${configCarousel.carouselId} a`).forEach(function(item) {
                        item.style.pointerEvents = 'all';
                    });
                });
            });
    
            // document.querySelectorAll(configCarousel.carouselId).forEach(function(item) {
            //     let trigger = 0;
            //     item.addEventListener('wheel', function(e) {
    
            //         console.log("PASA POR ACA AL ....")
    
            //         if(trigger !== 1) {
            //             ++trigger;
            //         } else {
            //             let change = e.deltaX * -3;
            //             let currentDelta = parseFloat(item.querySelector(configCarousel.carouselHolderId).style.transform.split('translateX(')[1]) || 0;
            //             scrollCarousel(change, currentDelta, item);
            //             trigger = 0;
            //         }
            //         e.preventDefault();
            //         e.stopImmediatePropagation();
            //         return false;
            //     });
            // });
    
        })
    }, 1000);
}