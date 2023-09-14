import { Component, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-img-slider',
  templateUrl: './img-slider.component.html',
  styleUrls: ['./img-slider.component.css'],
})
export class ImgSliderComponent {
  @Input() destinationId: any;
  constructor(private http: HttpClient) {}

  slideIndex = 0;
  images: any[] = [];

  ngOnInit() {
    this.getImagesById();
  }

  previousSlide() {
    if (this.slideIndex === 0) {
      this.slideIndex = this.images.length - 1;
    } else {
      this.slideIndex--;
    }
  }

  nextSlide() {
    if (this.slideIndex === this.images.length - 1) {
      this.slideIndex = 0;
    } else {
      this.slideIndex++;
    }
  }
  getImg(base64img: string) {
    const url = `data:image/jpg;base64,${base64img}`;
    return url;
  }
  getImagesById() {
    this.http
      .get<any[]>(
        'https://localhost:7272/api/DestinationImage?id=' + this.destinationId
      )
      .subscribe((img) => {
        this.images = img;
      });
  }
  deleteImage(imageId: any) {
  
    const url = 'https://localhost:7272/api/DestinationImage?id=' + imageId;
    this.http.delete(url)
      .subscribe(
        (response: any) => {
          this.getImagesById(); 
        },
        (error) => {
          alert('Greška prilikom brisanja slike.');
        }
      );
  }
}
