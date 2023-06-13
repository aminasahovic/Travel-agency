import { Component, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'appi-img-slider',
  templateUrl: './img-slider.component.html',
  styleUrls: ['./img-slider.component.css'],
})
export class ImgSliderComponent1 {
  @Input() destinationId!: number|null;
  images: any[] = [];
  slideIndex = 0;

  constructor(private http: HttpClient) {}

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
    return `data:image/jpg;base64,${base64img}`;
  }

  getImagesById() {
    this.http
      .get<any[]>('https://localhost:7272/api/AccommodationImage?id=' + this.destinationId)
      .subscribe((images) => {
        this.images = images;
      });
  }
}
